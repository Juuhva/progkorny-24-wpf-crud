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
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
            welcomeWindow.ResizeMode = ResizeMode.NoResize;

        }

        UserService us = new UserService();


        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User { Username = registerUserTxtBox.Text, Password = registerPassTxtBox.Password };
            us.AddUser(newUser);
            MessageBox.Show("Sikeres regisztráció!");
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (us.LoginUser(loginUserTxtBox.Text, loginPassTxtBox.Password) != null)
            {
                MessageBox.Show("Sikeres bejelentkezés!");
                UserInterface ui = new UserInterface();
                ui.Show();
            }
            else
            {
                MessageBox.Show("Sikertelen bejelentkezés!");

            }
        }
    }
}
