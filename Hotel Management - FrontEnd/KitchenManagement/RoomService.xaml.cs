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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotel_Management___FrontEnd
{
    /// <summary>
    /// Interaction logic for RoomService.xaml
    /// </summary>
    public partial class RoomService : Window
    {

        ReservationContext Reservation_Context { get; set; }

        BindingList<Reservation> Reservations;

        public RoomService()
        {
            InitializeComponent();
            Reservation_Context = new();

            Reservation_Context.Reservations.Load();

            TODOTabL.Reservation_Context = Reservation_Context;
            Overview.Reservation_Context = Reservation_Context;

            Closed += (sender, e) => Reservation_Context.Dispose();
        }
    }
}
