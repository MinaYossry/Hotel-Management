using Microsoft.EntityFrameworkCore;
using Reservation__DbContext.Models;
using System;
using System.Collections.Generic;
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
        Reservation_Context reservation_Context;
        List<Reservation> reservations;

        public Frontend()
        {
            InitializeComponent();
            reservation_Context = new();

            reservation_Context.Reservations.Load();
            reservations = reservation_Context.Reservations.Local.ToList();
            ReservationDataGrid.ItemsSource =  reservations;

            var OccupiedRooms = reservations.Where(r => r.CheckIn);
            var ReservedRooms = reservations.Where(r => !r.CheckIn);

            InsertRooms(OccupiedRooms, RoomAvailibiltyTap.OccupiedRoomsPanel);
            InsertRooms(ReservedRooms, RoomAvailibiltyTap.ReservedRoomsPanel);

            UniversalSearchTap.Reservation_Context = reservation_Context;
        }

        private void InsertRooms(IEnumerable<Reservation> Rooms, ListBox Target)
        {

            foreach (var Room in Rooms)
            {
                Target.Items.Add(CreateRow(Room));
            }
        }

        private UniformGrid CreateRow(Reservation Room)
        {
            UniformGrid NewItem = new();
            NewItem.Rows = 1;
            Label RoomNo = new();
            RoomNo.Content = Room.RoomNumber.Trim();

            Label RoomType = new();
            RoomType.Content = Room.RoomType.Trim();

            Label ID = new();
            ID.Content = Room.Id;

            Label RoomName = new();
            RoomName.Content = $"{Room.FirstName.Trim()} {Room.LastName.Trim()}";

            Label PhoneNo = new();
            PhoneNo.Content = Room.PhoneNumber.Trim();

            NewItem.Children.Add(RoomNo);
            NewItem.Children.Add(RoomType);
            NewItem.Children.Add(ID);
            NewItem.Children.Add(RoomName);
            NewItem.Children.Add(PhoneNo);

            return NewItem;
        }

        private void ReservationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
