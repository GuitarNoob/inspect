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
        string queryString = "";

        public WorkOrderReport(string query)
        {
            queryString = query;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MIETRAKReports"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public List<WorkOrderReportEntry> GetQuery()
        {
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
                    rdr["Days Out"].ToString()
                        ));
                }
            }

            CheckDueDates(ref returnList);
            return returnList;
        }

        public void CheckDueDates(ref List<WorkOrderReportEntry> input)
        {
            //RunTime is minutes per part
            //DaysOut
            //QuantityRequired Qty To Fab
            //Setup time
            string lastWorkorder = "";
            decimal constMultiplier = (decimal)1.5;
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
                        minuteCounter = minutesInDay;
                        rollingDueDate = DecementDueDate(rollingDueDate);
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
    }
}
