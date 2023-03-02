using DatabaseContext.Context;
using DatabaseContext.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel_Management___FrontEnd
{
    /// <summary>
    /// Interaction logic for RoomAvailibiltyTap.xaml
    /// </summary>
    public partial class RoomAvailibiltyTap : UserControl
    {
        public ReservationContext Reservation_Context { get; set; } 

        public RoomAvailibiltyTap()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Reservation_Context is not null)
            {
                OccupiedRoomsPanel.Items.Clear();
                ReservedRoomsPanel.Items.Clear();

                var OccupiedRooms = Reservation_Context.Reservations.Local.Where(r => r.CheckIn);
                var ReservedRooms = Reservation_Context.Reservations.Local.Where(r => !r.CheckIn);

                InsertRooms(OccupiedRooms, OccupiedRoomsPanel);
                InsertRooms(ReservedRooms, ReservedRoomsPanel);
            }
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
    }
}
