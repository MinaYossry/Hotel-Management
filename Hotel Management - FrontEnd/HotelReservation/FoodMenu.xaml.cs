using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotel_Management___FrontEnd
{
    /// <summary>
    /// Interaction logic for FoodMenu.xaml
    /// </summary>
    public partial class FoodMenu : Window
    {
        static int BreafastPrice { get; } = 7;
        static int LunchPrice { get; } = 15;
        static int DinnerPrice { get; } = 15;


        public int BreafastCount { get; set; }
        public int LunchCount { get; set; }
        public int DinnerCount { get; set; }

        public bool IsCleaning { get; set; }
        public bool IsTowels { get; set; }
        public bool IsSweatestSurprise { get; set; }

        public int TotalFoodBill { get; set; }

        public FoodMenu()
        {
            InitializeComponent();
        }

        private void Check_Breakfast_Checked(object sender, RoutedEventArgs e)
        {
            if (Check_Breakfast.IsChecked is not null)
                text_BreakfastCount.IsEnabled = (bool)Check_Breakfast.IsChecked;
        }

        private void Check_Lunch_Checked(object sender, RoutedEventArgs e)
        {
            if (Check_Lunch.IsChecked is not null)
                text_LunchCount.IsEnabled = (bool)Check_Lunch.IsChecked;
        }

        private void Check_Dinner_Checked(object sender, RoutedEventArgs e)
        {
            if (Check_Dinner.IsChecked is not null)
                text_DinnerCount.IsEnabled = (bool)Check_Dinner.IsChecked;
        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if  (Check_Breakfast.IsChecked == true)
            {
                if (int.TryParse(text_BreakfastCount.Text, out int count))
                {
                    BreafastCount = count;
                    TotalFoodBill += (count * BreafastPrice);
                }
            }

            if (Check_Lunch.IsChecked == true)
            {
                if (int.TryParse(text_LunchCount.Text, out int count))
                {
                    LunchCount = count;
                    TotalFoodBill += (count * LunchPrice);
                }
            }

            if (Check_Dinner.IsChecked == true)
            {
                if (int.TryParse(text_DinnerCount.Text, out int count))
                {
                    DinnerCount = count;
                    TotalFoodBill += (count * DinnerPrice);
                }
            }

            IsCleaning = Check_Cleaning.IsChecked == true;
            IsTowels = Check_Towels.IsChecked == true;
            IsSweatestSurprise = Check_SweetestSurprise.IsChecked == true;

            DialogResult = true;
            Close();
        }
    }
}
