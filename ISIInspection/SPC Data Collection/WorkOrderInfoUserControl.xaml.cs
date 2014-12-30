using MieTrakWrapper.MieTrak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SPC_Data_Collection
{
    /// <summary>
    /// Interaction logic for WorkOrderInfoUserControl.xaml
    /// </summary>
    public partial class WorkOrderInfoUserControl : UserControl
    {
        public WorkOrderInfoUserControl()
        {
            InitializeComponent();
        }

        public void FillTextBoxes(WorkOrder wo)
        {
            
            TxtBoxCustomerId.Text = wo.CustomerFK.ToString();
            TxtBoxDescription.Text = wo.ItemDescription;
            TxtBoxPartNumber.Text = wo.PartNumber;
            TxtBoxPartRevision.Text = wo.Revision;
            TxtBoxQuantityFab.Text = (wo.QuantityFab ?? (decimal)0).ToString("0");
            TxtBoxQuantityReq.Text = (wo.QuantityRequired ?? (decimal)0).ToString("0");
            TxtBoxRouter.Text = wo.RouterFK.ToString();
            TxtBoxWorkOrder.Text = wo.WorkOrderPK.ToString();
            TxtBoxStatus.Text = GetStatusEnum(wo.WorkOrderStatusFK).ToString();

            Party customer = App.Engine.Database.mietrakConn.mietrakDb.Parties.FirstOrDefault(x => x.PartyPK == wo.CustomerFK);
            TxtBoxCustomer.Text = customer.Name;
        }

        StatusEnum GetStatusEnum(int? enumInt)
        {
            if (enumInt == null)
                return StatusEnum.Unknown;
            return (StatusEnum)enumInt;
        }
    }

    enum StatusEnum
    {
        Unknown,
        Open = 2,
        Production_Hold = 3,
        Closed = 4,
        Cancelled = 5
    }
}
