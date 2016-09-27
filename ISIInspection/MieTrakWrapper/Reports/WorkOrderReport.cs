using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MieTrakWrapper.Reports
{

    public enum WorkOrderReportSort
    {
        Unknown,
        WorkOrderSort,
        SalesOrderSort
    }

    public enum WorkOrderReportFilter
    {
        NoFilter,
        AssemblyDeburr,
        Shipping,
        MillLathe
    }

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
,assem.QuantityProduced as 'Qty Complete'
,assem.OperationFK as 'OperationKey'
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

        public static Int64[] deburrNums =
        {
            15,//   Sanding
            16,//   Scotch Brite
            17,//   Rout-A-Burr
            18,//   Countersink
            19,//   X-ACTO Knife
            20,//   File
            21,//   Deburr Wheel
            22,//   Sand Blast
            23,//   Soap & Water
            24,//   Acetone
            25,//   Air Blow
            29,//   Chamfer
            30,//   Machine Set-up
            31,//   Wire Brush Wheel
            32,//   3M Wheel
            34,//   Ball Pressing
            35,//   Pin Pressing
            36,//   Pem-Nut Pressing
            39,//   Bending
            40,//   Helicoils
            41,//   Tumble
            42,//   Assemble
            43,//   Arbor Press
            44,//   Set Screw
            46,//   Press
            48,//   Hand Tap Deburr
            49,//    Straighten
            50,//    Dremel
            54,//    Jitter Bug/Hand Sand
            55//     Deburr
        };

        public static Int64[] shippingNums =
        {
            26, //Outside Process
            27, //Packaging
            28 //Shipping
        };

        public static Int64[] millingNums =
        {
            6,//    VF2-1
            7,//    VF2-2
            8,//    SMV-1000-1
            9,//    SMV-1000-2
            10,//    SMV-600-1
            11,//    SMV-600-2
            52,//    VF4-1
            66,//    VM OP-1
            67,//    VM OP-2
            68,//    VM OP-3
            69,//    VM OP-4
            70,//    VM OP-5
            71,//    VM OP-6
            72,//    VM OP-7
            73,//    VM OP-8
            76,//    VM OP-9
            77,//    VM OP-10
            78,//    VM OP-11
            79,//    VM OP-12
            12,//    TS-814-1 LATHE
            13,//    WASINO LATHE
            38,//    CNC Lathe
            80,//    LT OP-1
            81 //    LT OP-2
        };

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

        public List<WorkOrderReportEntry> GetQuery(decimal multiplier, WorkOrderReportSort sort, WorkOrderReportFilter filter)
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
                    rdr["WorkOrderStatus"].ToString(),
                    rdr["Qty Complete"].ToString(),
                    rdr["OperationKey"].ToString()
                        ));
                }
            }

            CheckActiveEmployees(ref returnList, GetActiveEmployees());
            CheckDueDates(ref returnList);
            returnList = FilterReport(returnList);
            returnList = SortReport(returnList, sort);
            returnList = FilterReportByEnum(returnList, filter);
            return returnList;
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

        List<WorkOrderReportEntry> SortReport(List<WorkOrderReportEntry> inputList, WorkOrderReportSort sort)
        {
            if (sort == WorkOrderReportSort.WorkOrderSort)
            {
                return inputList.OrderBy(x => x.WorkOrder).ThenBy(x => x.DueDate_DateTime).ThenBy(x => x.PartNumber).ToList();
            }
            else if (sort == WorkOrderReportSort.SalesOrderSort)
            {
                return inputList.OrderBy(x => x.SalesOrderFK).ThenBy(x => x.DueDate_DateTime).ThenBy(x => x.PartNumber).ToList();
            }

            return null;
        }

        List<WorkOrderReportEntry> FilterReportByEnum(List<WorkOrderReportEntry> inputList, WorkOrderReportFilter filter)
        {
            if (filter == WorkOrderReportFilter.NoFilter)
            {
                return inputList;
            }

            List<WorkOrderReportEntry> returnList = new List<WorkOrderReportEntry>();
            foreach (WorkOrderReportEntry entry in inputList)
            {
                bool shouldAdd = false;
                Int64 opKey = entry.GetOperationKey();
                if (filter == WorkOrderReportFilter.AssemblyDeburr)
                {
                    if (deburrNums.Contains(opKey))
                    {
                        shouldAdd = true;
                    }
                }
                else if (filter == WorkOrderReportFilter.Shipping)
                {
                    if (shippingNums.Contains(opKey))
                    {
                        shouldAdd = true;
                    }
                }
                else if (filter == WorkOrderReportFilter.MillLathe)
                {
                    if (millingNums.Contains(opKey))
                    {
                        shouldAdd = true;
                    }
                }

                if (shouldAdd)
                {
                    returnList.Add(entry);
                }
            }
            return returnList;
        }
    }
}
