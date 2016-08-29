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
         ,assem.OutsideProcessingDescription as 'Finish'
         ,assem.TargetDueDate as 'Op Complete Date'
         ,workorder.CustomerOnDockDate 'Due Date'
                --,assem.WorkOrderAssemblyLaborStatusFK
                --,workorder.WorkOrderStatusFK
  
  FROM [MIETRAK].[dbo].[WorkOrder] workorder
    
  inner join [MIETRAK].[dbo].[WorkOrderAssembly] assem
  on assem.WorkOrderFK = workorder.WorkOrderPK  

  inner join [MIETRAK].[dbo].[Operation] op
  on assem.OperationFK = op.OperationPK   

  inner join [MIETRAK].[dbo].[Party] cust
  on workorder.CustomerFK = cust.PartyPK 

  WHERE 
  workorder.WorkOrderStatusFK = 2 
  AND 
  assem.WorkOrderAssemblyLaborStatusFK = 1

  ORDER BY workorder.CustomerOnDockDate, workorder.PartNumber";

        public WorkOrderReport()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MIETRAKReports"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public DataTable GetQuery()
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataTable returnTable = new DataTable();
            adapter.Fill(returnTable);
            return returnTable;
        }
    }
}
