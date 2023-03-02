using DatabaseContext.Context;
using DatabaseContext.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotel_Management___FrontEnd
{
    /// <summary>
    /// Interaction logic for Frontend.xaml
    /// </summary>
    public partial class Frontend : Window
    {
        ReservationContext Reservation_Context;
        BindingList<Reservation> Reservations;

        public Frontend()
        {
            InitializeComponent();
            Reservation_Context = new();

            Reservation_Context.Reservations.Load();
            Reservations = Reservation_Context.Reservations.Local.ToBindingList();
            ReservationDataGrid.ItemsSource = Reservations;

            UniversalSearchTap.Reservation_Context = Reservation_Context;
            ReservationPageTap.Reservation_Context = Reservation_Context;

            RoomAvailibiltyTab.Reservation_Context = Reservation_Context;

            ReservationPageTap.Res_SelectReservation.ItemsSource = Reservations;
            ReservationPageTap.Res_SelectReservation.SelectedValuePath = "Id";

            Closed += (sender, e) => Reservation_Context.Dispose();
        }

        

        private void ReservationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TabItem currentTab = e.AddedItems[0] as TabItem;
                if (currentTab is not null && currentTab == RoomAvailable)
                {
                    
                }
            }
            catch
            {
            }
        }
    }
}
