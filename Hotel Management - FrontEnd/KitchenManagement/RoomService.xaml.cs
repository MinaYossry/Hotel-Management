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
        List<Reservation> ReservationList { get; set; }

        public RoomService()
        {
            InitializeComponent();
            Reservation_Context = new();

            ReservationList = Reservation_Context.Reservations.Where(res => res.CheckIn && !res.SupplyStatus).ToList();

            TODOTabL.Reservation_Context = Reservation_Context;
            TODOTabL.ReservationList = ReservationList;

            Overview.ReservationList = ReservationList;
            TODOTabL.ReservationListChanged += Overview.Overview_ReservationListChanged;

            Closed += (sender, e) => Reservation_Context.Dispose();
        }
    }
}
