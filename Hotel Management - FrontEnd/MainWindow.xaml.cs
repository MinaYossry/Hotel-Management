using DatabaseContext.Context;
using DatabaseContext.Entities;
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
        LoginContext Login_Manager_Context;

        public MainWindow()
        {
            InitializeComponent();

            Login_Manager_Context = new();

            Loaded += (sender, e) => LoginUsername.Focus();
            Closed += (sender, e) => Login_Manager_Context.Dispose();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var UserName = LoginUsername.Text;
            var Password = LoginPassword.Password;

            if (HotelUsers.Validate(UserName, Password, Login_Manager_Context.HotelUsers))
            {
                this.Hide();
                Frontend frontEndScreen = new();
                frontEndScreen.Show();

                frontEndScreen.Closed += (sender, e) => Close();
            }
            else if (KitchenUsers.Validate(UserName, Password, Login_Manager_Context.KitchenUsers))
            {
                this.Hide();
                RoomService roomService = new RoomService();
                roomService.Show();
                roomService.Closed += (sender, e) => Close();
            }
            else
                MessageBox.Show("Failed");
        }


    }
}
