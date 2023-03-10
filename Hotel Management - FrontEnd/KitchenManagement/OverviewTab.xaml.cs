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
    /// Interaction logic for OverviewTab.xaml
    /// </summary>
    public partial class OverviewTab : UserControl
    {
        public List<Reservation> ReservationList { get; set; }

        public OverviewTab()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            OverviewDataGrid.ItemsSource = ReservationList;
        }

        public void Overview_ReservationListChanged(object sender, EventArgs e)
        {
            OverviewDataGrid.ItemsSource = null;
            OverviewDataGrid.ItemsSource = ReservationList;
        }
    }
}
