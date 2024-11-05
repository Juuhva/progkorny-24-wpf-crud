using Org.BouncyCastle.Asn1.Cmp;
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
using System.Windows.Shapes;

namespace CRUD
{
    /// <summary>
    /// Interaction logic for UserInterface.xaml
    /// </summary>
    public partial class UserInterface : Window
    {
        public UserInterface()
        {
            InitializeComponent();
            userInterfaceWindow.ResizeMode = ResizeMode.NoResize;
        }

        public void RefreshUsers()
        {
            List<User> users = us.ListUsers();
            UsersDataGrid.ItemsSource = users;
        }

        public User user { get; private set; }

        private UserService us = new UserService();


        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            us.DeleteUser(Convert.ToInt32(idTxtBox.Text));
            MessageBox.Show("Sikeres törlés!");
            RefreshUsers();
        }

        private void modifyBtn_Click(object sender, RoutedEventArgs e)
        {
            us.ListUsers();
            if (int.TryParse(idTxtBox.Text, out int userId) && !string.IsNullOrEmpty(userTxtBox.Text) && !string.IsNullOrEmpty(passTxtBox.Text))
            {
                User user = new User
                {
                    Id = userId,
                    Username = userTxtBox.Text,
                    Password = passTxtBox.Text
                };

                us.UpdateUser(user);
                MessageBox.Show("Sikeres módosítás!");
                RefreshUsers();
            }
            else
            {
                MessageBox.Show("Minden mezőt ki kell töltenie!");
            }
        }

        private void listBtn_Click(object sender, RoutedEventArgs e)
        {
            RefreshUsers();
        }
    }
}
