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
    /// Interaction logic for UniversalSearch.xaml
    /// </summary>
    public partial class UniversalSearch : UserControl
    {
        public ReservationContext Reservation_Context { get; set; }

        public UniversalSearch()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string SearchText = SearcBox.Text;

            if (SearchText != "")
            {
                var SearchResult = (from Room in Reservation_Context.Reservations
                                   where Room.Id.ToString().Contains(SearchText)
                                   || Room.LastName.Contains(SearchText)
                                   || Room.FirstName.Contains(SearchText)
                                   || Room.Gender.Contains(SearchText)
                                   || Room.State.Contains(SearchText)
                                   || Room.City.Contains(SearchText)
                                   || Room.RoomNumber.Contains(SearchText)
                                   || Room.RoomType.Contains(SearchText)
                                   || Room.EmailAddress.Contains(SearchText)
                                   || Room.PhoneNumber.Contains(SearchText)
                                   select Room).ToList();

                SearchResultDataGrid.ItemsSource = SearchResult;
            }
            else
            {
                MessageBox.Show("Insert Text to search for", "Empty Search", MessageBoxButton.OK);
            }

                                 
        }
    }
}
