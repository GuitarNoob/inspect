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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LogonWindow : Window
    {
        Dictionary<string, User> userList = new Dictionary<string, User>();
        Dictionary<string, string> userListByID = new Dictionary<string, string>();

        bool loggedIn = false;

        public LogonWindow()
        {
            InitializeComponent();
            LoadUsers();
        }

        void LoadUsers()
        {
            userList.Clear();
            userListByID.Clear();
            List<User> mietrakUsers = App.Engine.Database.mietrakConn.mietrakDb.Users.Where(x => (x.Enabled ?? false) == true).ToList();
            foreach (User user in mietrakUsers)
            {
                string comboBoxName = App.Engine.GetUserDisplayName(user);
                string id = user.Code;
                userList.Add(comboBoxName, user);
                if (!userListByID.ContainsKey(id))
                    userListByID.Add(id, comboBoxName);
            }

            ComboBoxUsers.ItemsSource = userList.Keys;
            ComboBoxUsers.Focus();
        }

        private void ButtonLogon_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = ComboBoxUsers.SelectedItem;
            if (selectedItem != null)
            {
                if (userList.ContainsKey((selectedItem as string)))
                {
                    User selectedUser = userList[selectedItem as string];
                    if (UserPassword.Password == selectedUser.Password)
                    {
                        App.Engine.LogonUser(selectedUser);
                        loggedIn = true;
                        this.DialogResult = true;
                    }
                    else
                        MessageBox.Show("Incorrect password entered.");
                }
            }
            else
                MessageBox.Show("The user selected cannot be found.");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!loggedIn)
                e.Cancel = true;
        }

        private void UserID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (userListByID.ContainsKey(UserID.Text))
                ComboBoxUsers.SelectedItem = userListByID[UserID.Text];
        }
    }
}
