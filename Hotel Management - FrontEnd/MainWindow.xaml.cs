using Login_DbContext.LoginDbContext;
using Login_DbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace Hotel_Management___FrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Login_Manager Login_Manager_Context;

        public MainWindow()
        {
            InitializeComponent();

            Login_Manager_Context = new();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var UserName = LoginUsername.Text;
            var Password = LoginPassword.Password;

            if (Login_DbContext.Models.Frontend.Validate(UserName, Password, Login_Manager_Context.Frontends))
            {
                this.Hide();
                Frontend frontEndScreen = new();
                frontEndScreen.Show();

                frontEndScreen.Closed += (sender, e) => Close();
            }
            else if (Kitchen.Validate(UserName, Password, Login_Manager_Context.Kitchens))
            {
                this.Hide();
            }
            else
                MessageBox.Show("Failed");
        }


    }
}
