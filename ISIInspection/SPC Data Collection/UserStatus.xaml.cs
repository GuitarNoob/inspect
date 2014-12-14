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
    /// Interaction logic for UserStatus.xaml
    /// </summary>
    public partial class UserStatus : UserControl
    {
        public UserStatus()
        {
            InitializeComponent();
            App.UserChanged += App_UserChanged;
        }

        void App_UserChanged(object sender, EventArgs e)
        {
            if (App.CurrentUser == null)
            {
                ButtonLoginLogout.Content = "Login";
                LabelCurrentUser.Content = "Unknown";
            }
            else
            {
                ButtonLoginLogout.Content = "Logout";
                LabelCurrentUser.Content = App.GetUserDisplayName(App.CurrentUser);
            }
        }

        private void ButtonLoginLogout_Click(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser == null)
            {
                //can this happen?
                //the main window forces a login window
                //LogonWindow win = new LogonWindow();
                //win.ShowDialog();
            }
            else
            {
                App.LogonUser(null);
            }
        }
    }
}
