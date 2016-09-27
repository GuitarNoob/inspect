using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MieTrakWrapper.Reports
{
    public class WorkOrderReport
    {
        SqlConnection connection;
        string queryString = @"SELECT TOP 1000
          workorder.WorkOrderPK as 'Work Order'
         ,cust.Name as 'Customer'
              ,workorder.QuantityRequired as 'Qty To Fab'
         ,workorder.PartNumber as 'Part Number'
         ,workorder.ItemDescription 'Description'
         ,op.Name as 'Operation'
              ,wc.Description AS 'Work Center'
         ,assem.OutsideProcessingDescription as 'Finish'
              ,assem.SetupTime as 'Setup Time'
              ,assem.MinutesPerPart as 'Run Time'
         ,assem.TargetDueDate as 'Op Complete Date'
         ,workorder.CustomerOnDockDate 'Due Date'
         ,assem.DaysOut as 'Days Out'
         ,assem.WorkOrderAssemblyPK as 'AssemblyPK'
         ,woJob.SalesOrderFK as 'Sales Order'
,assem.WorkOrderAssemblyLaborStatusFK as 'WorkOrderStatus'
                --,assem.WorkOrderAssemblyLaborStatusFK
                --,workorder.WorkOrderStatusFK
 
  FROM [MIETRAK].[dbo].[WorkOrder] workorder
   
  inner join [MIETRAK].[dbo].[WorkOrderAssembly] assem
  on assem.WorkOrderFK = workorder.WorkOrderPK 
 
  inner join [MIETRAK].[dbo].[Operation] op
  on assem.OperationFK = op.OperationPK  
 
  inner join [MIETRAK].[dbo].[Party] cust
  on workorder.CustomerFK = cust.PartyPK
 
  inner join [MIETRAK].[dbo].[WorkCenter] wc
  on assem.WorkCenterFK = wc.WorkCenterPK
 
  inner join [MIETRAK].[dbo].[WorkOrderJob] woJob
  on woJob.WorkOrderFK = workorder.WorkOrderPK

  WHERE
  workorder.WorkOrderStatusFK = 2
  --AND
  --assem.WorkOrderAssemblyLaborStatusFK = 1
 
  ORDER BY workorder.CustomerOnDockDate, workorder.PartNumber";
        decimal constMultiplier = (decimal)1.5;
        bool showDetailedReport;

        public WorkOrderReport(bool showDetailed)
        {
            showDetailedReport = showDetailed;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MIETRAKReports"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        string GetCurrentEmployeeQuery()
        {
            return @"SELECT TOP 1000 [WorkOrderCollectionPK]
                    ,assem.WorkOrderFK as 'Work Order'
	                ,assem.WorkOrderAssemblyPK as 'Assembly'
	                ,users.FirstName as 'First Name'
	                ,users.LastName as 'Last Name'  
                FROM [MIETRAK].[dbo].[WorkOrderCollection] workCollection

                inner join [MIETRAK].[dbo].[WorkOrderAssembly] assem
                on assem.WorkOrderAssemblyPK = workCollection.WorkOrderAssemblyNumber 

                inner join [MIETRAK].[dbo].[User] users
                on users.UserPK = workCollection.EmployeeFK

                WHERE workCollection.IsActive != 0";
        }

        public List<WorkOrderReportEntry> GetQuery(decimal multiplier)
        {
            constMultiplier = multiplier;
            List<WorkOrderReportEntry> returnList = new List<WorkOrderReportEntry>();
            SqlCommand command = new SqlCommand(queryString, connection);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            using (SqlDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    returnList.Add(new WorkOrderReportEntry(
                    rdr["Work Order"].ToString(),
                    rdr["Customer"].ToString(),
                    rdr["Qty To Fab"].ToString(),
                    rdr["Part Number"].ToString(),
                    rdr["Description"].ToString(),
                    rdr["Operation"].ToString(),
                    rdr["Work Center"].ToString(),
                    rdr["Finish"].ToString(),
                    rdr["Setup Time"].ToString(),
                    rdr["Run Time"].ToString(),
                    rdr["Op Complete Date"].ToString(),
                    rdr["Due Date"].ToString(),
                    rdr["Days Out"].ToString(),
                    rdr["AssemblyPK"].ToString(),
                    rdr["Sales Order"].ToString(),
                    rdr["WorkOrderStatus"].ToString()
                        ));
                }
            }

            CheckActiveEmployees(ref returnList, GetActiveEmployees());
            CheckDueDates(ref returnList);
            return FilterReport(returnList);
        }

        List<ActiveEmployeeEntry> GetActiveEmployees()
        {
            List<ActiveEmployeeEntry> returnList = new List<ActiveEmployeeEntry>();
            SqlCommand command = new SqlCommand(GetCurrentEmployeeQuery(), connection);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            using (SqlDataReader rdr = command.ExecuteReader())
            {
                while (rdr.Read())
                {
                    returnList.Add(new ActiveEmployeeEntry(
                    rdr["Work Order"].ToString(),
                    rdr["Assembly"].ToString(),
                    rdr["First Name"].ToString(),
                    rdr["Last Name"].ToString()
                        ));
                }
            }
            return returnList;
        }

        public void CheckActiveEmployees(ref List<WorkOrderReportEntry> input, List<ActiveEmployeeEntry> activeEmployees)
        {
            foreach (WorkOrderReportEntry entry in input)
            {
                List<ActiveEmployeeEntry> active = activeEmployees.Where(x => x.WorkOrderAssemblyPK.Equals(entry.AssemblyFK)).ToList();
                if (active.Count > 0)
                {
                    bool firstEmployee = true;
                    string personNames = "";
                    foreach (ActiveEmployeeEntry employee in active)
                    {
                        if (!firstEmployee)
                        {
                            personNames += ", ";
                        }
                        personNames += employee.FirstName + " " + employee.LastName;                        
                        firstEmployee = false;
                    }
                    entry.SetActiveEmployees(personNames);
                }                
            }
        }

        public void CheckDueDates(ref List<WorkOrderReportEntry> input)
        {
            //RunTime is minutes per part
            //DaysOut
            //QuantityRequired Qty To Fab
            //Setup time
            string lastWorkorder = "";
            int hoursInDay = 8;
            int minutesInDay = hoursInDay * 60;
            int minuteCounter = 0;
            DateTime rollingDueDate = DateTime.Now;

            for (int i = (input.Count - 1); i >= 0; i--)
            {
                if (input[i].WorkOrder != lastWorkorder)
                {
                    lastWorkorder = input[i].WorkOrder;
                    minuteCounter = minutesInDay;
                    DateTime actualDueDate = DateTime.Parse(input[i].DueDate);
                    rollingDueDate = DecementDueDate(actualDueDate); //subtract 1 right away
                }

                decimal minPerPart = 0;
                decimal.TryParse(input[i].RunTime, out minPerPart);
                decimal qtyRqd = 0;
                decimal.TryParse(input[i].QtyToFab, out qtyRqd);
                decimal setupTime = 0;
                decimal.TryParse(input[i].SetupTime, out setupTime);
                decimal daysOut = 0;
                decimal.TryParse(input[i].DaysOut, out daysOut);
                if (daysOut > 0)
                {
                    minuteCounter = minutesInDay;
                    rollingDueDate = DecementDueDate(rollingDueDate, Convert.ToInt32(daysOut));
                }
                else
                {
                    decimal totalTimeRqd = (((minPerPart * qtyRqd) + setupTime) * constMultiplier);
                    int totalTimeInt = Convert.ToInt32(totalTimeRqd);
                    minuteCounter -= totalTimeInt;
                    if (minuteCounter < 0)
                    {
                        while (minuteCounter < 0)
                        {
                            minuteCounter += minutesInDay;
                            rollingDueDate = DecementDueDate(rollingDueDate);
                        }
                    }
                }

                input[i].OpCompleteDate = rollingDueDate.ToString();
                if (DateTime.Now > rollingDueDate)
                {
                    input[i].IsLate = "1";
                }
                else if ((DateTime.Now.AddDays(1)) > rollingDueDate)
                {
                    input[i].IsAlmostLate = "1";
                }
            }
        }

        DateTime DecementDueDate(DateTime inDate, int daysToSubtract = 1)
        {
            DateTime returnDay = inDate;
            for (int i = 0; i < daysToSubtract; i++)
            {
                returnDay = returnDay.AddDays(-1);
                while ((returnDay.DayOfWeek == DayOfWeek.Saturday) || (returnDay.DayOfWeek == DayOfWeek.Sunday))
                {
                    returnDay = returnDay.AddDays(-1);
                }
            }
            return returnDay;
        }

        List<WorkOrderReportEntry> FilterReport(List<WorkOrderReportEntry> inputList)
        {
            List<WorkOrderReportEntry> returnList = new List<WorkOrderReportEntry>();
            foreach (WorkOrderReportEntry entry in inputList)
            {
                if (showDetailedReport
                    || entry.IsInProgress())
                {
                    returnList.Add(entry);
                }
            }
            return returnList;
        }
    }
}
