using DatabaseContext.Context;
using DatabaseContext.Entities;
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

namespace Hotel_Management___FrontEnd
{
    /// <summary>
    /// Interaction logic for TODOTab.xaml
    /// </summary>
    public partial class TODOTab : UserControl
    {
        public ReservationContext Reservation_Context { get; set; }
        Reservation SelectedReservation { get; set; }

        public TODOTab()
        {
            InitializeComponent();
            
        }

        private void btn_UpdateChanges_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedReservation is not null)
            {
                try
                {
                    if (Reservation_Context.SaveChanges() > 0)
                    {
                        MessageBox.Show($"Reservation with ID: {SelectedReservation.Id} was updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        OverviewListBox.ItemsSource = Reservation_Context.Reservations.Local.Where(res => res.CheckIn && !res.SupplyStatus).ToList();
                        OverviewListBox.SelectedIndex = 0;
                    }
                }
                catch
                {
                    MessageBox.Show($"Couldn't update reservation", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

        private void OverviewListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                SelectedReservation = e.AddedItems[0] as Reservation;

                DataContext = SelectedReservation;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedReservation is not null) 
            {
                int OldFoodBill = SelectedReservation.FoodBill;

                FoodMenu foodMenu = new FoodMenu();

                foodMenu.DataContext = SelectedReservation;

                foodMenu.Check_Breakfast.IsChecked = SelectedReservation.BreakFast != 0;
                foodMenu.Check_Lunch.IsChecked = SelectedReservation.Lunch != 0;
                foodMenu.Check_Dinner.IsChecked = SelectedReservation.Dinner != 0;

                if (foodMenu.ShowDialog() == true)
                {
                    SelectedReservation.FoodBill = foodMenu.TotalFoodBill;
                    SelectedReservation.TotalBill += (SelectedReservation.FoodBill - OldFoodBill);
                }
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            OverviewListBox.ItemsSource = Reservation_Context.Reservations.Local.Where(res => res.CheckIn && !res.SupplyStatus).ToList();
            OverviewListBox.SelectedIndex = 0;
        }
    }
}
