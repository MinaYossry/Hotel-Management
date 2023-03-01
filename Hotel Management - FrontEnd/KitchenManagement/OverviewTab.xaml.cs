using DatabaseContext.Context;
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
    /// Interaction logic for OverviewTab.xaml
    /// </summary>
    public partial class OverviewTab : UserControl
    {
        public ReservationContext Reservation_Context { get; set; }

        public OverviewTab()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            OverviewDataGrid.ItemsSource = Reservation_Context.Reservations.Local.Where(res => res.CheckIn && !res.SupplyStatus).ToList();
        }
    }
}
