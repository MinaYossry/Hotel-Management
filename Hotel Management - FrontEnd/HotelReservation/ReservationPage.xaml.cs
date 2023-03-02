using DatabaseContext.Context;
using DatabaseContext.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
using System.Xml.Linq;

namespace Hotel_Management___FrontEnd
{
    /// <summary>
    /// Interaction logic for ReservationPage.xaml
    /// </summary>
    public partial class ReservationPage : UserControl
    {
        private readonly List<string> Genders = new() { "Male", "Female", "Other" };

        private readonly List<string> States = new ()
        {
            "Alabama",
            "Alaska",
            "Arizona",
            "Arkansas",
            "California",
            "Colorado",
            "Connecticut",
            "Delaware",
            "Florida",
            "Georgia",
            "Hawaii",
            "Idaho",
            "Illinois",
            "Indiana",
            "Iowa",
            "Kansas",
            "Kentucky",
            "Louisiana",
            "Maine",
            "Maryland",
            "Massachusetts",
            "Michigan",
            "Minnesota",
            "Mississippi",
            "Missouri",
            "Montana",
            "Nebraska",
            "Nevada",
            "New Hampshire",
            "New Jersey",
            "New Mexico",
            "New York",
            "North Carolina",
            "North Dakota",
            "Ohio",
            "Oklahoma",
            "Oregon",
            "Pennsylvania",
            "Rhode Island",
            "South Carolina",
            "South Dakota",
            "Tennessee",
            "Texas",
            "Utah",
            "Vermont",
            "Virginia",
            "Washington",
            "West Virginia",
            "Wisconsin",
            "Wyoming"
        };

        private readonly List<int> NumberOfGuests = new () { 1, 2, 3, 4, 5, 6 };
         
        private readonly List<string> RoomTypes = new() { "Single", "Double", "Twin", "Dublex", "Suite" };

        private readonly List<string> RoomFloorNumbers = new()  { "1", "2", "3", "4", "5" };

        private readonly List<string> RoomsNumbers = new()
        {
                "101",
                "102",
                "103",
                "104",
                "105",
                "106",
                "107",
                "108",
                "109",
                "110",
                "201",
                "202",
                "203",
                "204",
                "205",
                "206",
                "207",
                "208",
                "209",
                "210",
                "301",
                "302",
                "303",
                "304",
                "305",
                "306",
                "307",
                "308",
                "309",
                "310",
                "401",
                "402",
                "403",
                "404",
                "405",
                "406",
                "407",
                "408",
                "409",
                "410",
                "501",
                "502",
                "503",
                "504",
                "505",
                "506",
                "507",
                "508",
                "509",
                "510",
        };

        public ReservationContext Reservation_Context { get; set; }

        public int TotalAmount { get; set; }

        public string CC_ExpireMonth { get; set; }
        public string CC_ExpireYear { get; set; }

        public int FoodBill { get; set; }

        private Reservation SelectedReservation { get; set; } = new() { ArrivalTime = DateTime.Today, LeavingTime = DateTime.Today.AddDays(1) };

        public ReservationPage()
        {
            InitializeComponent();
            Res_EntryDate.SelectedDate =  Res_EntryDate.DisplayDateStart = DateTime.Today;
            Res_DepartureDate.SelectedDate =  Res_DepartureDate.DisplayDateStart = DateTime.Today.AddDays(1);
            ReservationGrid.DataContext = SelectedReservation;

            Res_Gender.ItemsSource = Genders;
            Res_State.ItemsSource = States;
            Res_NoOfGuests.ItemsSource = NumberOfGuests;
            Res_RoomType.ItemsSource = RoomTypes;
            Res_Floor.ItemsSource = RoomFloorNumbers;
            Res_RoomNumber.ItemsSource = RoomsNumbers;
        }

        private void btn_FoodMenu_Click(object sender, RoutedEventArgs e)
        {
            FoodMenu foodMenu = new FoodMenu();

            foodMenu.DataContext = SelectedReservation;

            foodMenu.Check_Breakfast.IsChecked = SelectedReservation.BreakFast != 0;
            foodMenu.Check_Lunch.IsChecked = SelectedReservation.Lunch != 0;
            foodMenu.Check_Dinner.IsChecked = SelectedReservation.Dinner != 0;

            if(foodMenu.ShowDialog() == true)
            {
                SelectedReservation.FoodBill = foodMenu.TotalFoodBill;
            }
        }

        private void btn_FinalizeBill_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedReservation.BreakFast == 0 && SelectedReservation.Lunch == 0 && SelectedReservation.Dinner == 0 && !SelectedReservation.Cleaning && !SelectedReservation.Towel && !SelectedReservation.SSurprise) 
            {
                Res_FoodStatus.IsChecked = true;
            }
            else
            {
                Res_FoodStatus.IsChecked = false;
            }

            if (CalculateBill())
            {
                FinalizeBill finalizeBill = new FinalizeBill();
                finalizeBill.TotalAmount = TotalAmount;
                finalizeBill.FoodBill = SelectedReservation.FoodBill;
                finalizeBill.DataContext = SelectedReservation;

                finalizeBill.CC_Month.SelectedValue = CC_ExpireMonth;
                finalizeBill.CC_Year.SelectedValue = CC_ExpireYear;

                if (finalizeBill.ShowDialog() == true)
                {
                    SelectedReservation.TotalBill = finalizeBill.FinalTotalBill;
                    CC_ExpireMonth = finalizeBill.CC_Month.Text;
                    CC_ExpireYear = finalizeBill.CC_Year.Text;
                    SelectedReservation.CardExp = $"{CC_ExpireMonth}/{CC_ExpireYear}";

                    if (btn_Update.IsVisible == false)
                        btn_Submit.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show($"Cancelled");
                }
            }
        }


        private void btn_EditReservation_Click(object sender, RoutedEventArgs e)
        {
            btn_Submit.Visibility = Visibility.Hidden;
            btn_Delete.Visibility = Visibility.Visible;
            btn_Update.Visibility = Visibility.Visible;
            Res_SelectReservation.Visibility = Visibility.Visible;
        }

        private bool CalculateBill()
        {
            switch (SelectedReservation.RoomType)
            {
                case "Single":
                    TotalAmount = 149;
                    Res_Floor.SelectedValue = "1";
                    break;
                case "Double":
                    TotalAmount = 299;
                    Res_Floor.SelectedValue = "2";
                    break;
                case "Twin":
                    TotalAmount = 349;
                    Res_Floor.SelectedValue = "3";
                    break;
                case "Dublex":
                    TotalAmount = 399;
                    Res_Floor.SelectedValue = "4";
                    break;
                case "Suite":
                    TotalAmount = 499;
                    Res_Floor.SelectedValue = "5";
                    break;
                default:
                    MessageBox.Show("Must select room type");
                    return false;
            }

            if (int.TryParse((Res_NoOfGuests?.Text ?? "NA"), out int SelectionTemp))
            {
                if (SelectionTemp >= 3)
                    TotalAmount += (SelectionTemp * 5);
            }
            else
            {
                MessageBox.Show("Enter # of Guests first", "Error Parsing", MessageBoxButton.OK);
                return false;
            }

            return true;
        }

        private bool AllDataIsValid()
        {
            return Res_FirstName.Text != "" && Res_LastName.Text != ""
                && Res_BirthDate.SelectedDate is not null
                && Res_Gender.SelectedItem is not null
                && Res_PhoneNumber.Text != ""
                && Red_Email.Text != ""
                && Res_StreetAddress.Text != ""
                && Res_AptNumber.Text != ""
                && Res_City.Text != ""
                && Res_State.SelectedItem is not null
                && Res_ZipCode.Text != ""
                && Res_NoOfGuests.SelectedItem is not null
                && Res_RoomType.SelectedItem is not null
                && Res_Floor.SelectedItem is not null
                && Res_RoomNumber.SelectedItem is not null
                && Res_EntryDate.SelectedDate <= Res_DepartureDate.SelectedDate;

        }

        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (AllDataIsValid())
            {
                try
                {
                    Reservation_Context.Add(SelectedReservation);
                    if(Reservation_Context.SaveChanges() > 0)
                    {
                        MessageBox.Show($"Reservation with ID: {SelectedReservation.Id} was inserted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        SendSMS();
                    }
                }
                catch
                {
                    MessageBox.Show($"Couldn't make new reservation", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
                MessageBox.Show("Must Enter All Fields", "Field Empty", MessageBoxButton.OK);
        }


        private void Res_SelectReservation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedReservation = e.AddedItems[0] as Reservation;


            if(SelectedReservation is not null)
            {
                ReservationGrid.DataContext = SelectedReservation;
                CC_ExpireMonth = SelectedReservation.CardExp.Substring(0, 2);
                CC_ExpireYear = SelectedReservation.CardExp.Substring(3, 2);
            }
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    if (Reservation_Context.SaveChanges() > 0)
                    {
                        MessageBox.Show($"Reservation with ID: {SelectedReservation.Id} was updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch
                {
                    MessageBox.Show($"Couldn't update reservation", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);

                }
        }

        private void btn_NewReservation_Click(object sender, RoutedEventArgs e)
        {
            SelectedReservation = new() {  ArrivalTime = DateTime.Today, LeavingTime = DateTime.Today.AddDays(1) };

            ReservationGrid.DataContext = SelectedReservation;

            btn_Delete.Visibility = Visibility.Hidden;
            btn_Update.Visibility = Visibility.Hidden;
            Res_SelectReservation.Visibility = Visibility.Hidden;
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Reservation DeletedReservation = SelectedReservation;

            try
            {
                Res_SelectReservation.SelectedIndex = 0;
                Reservation_Context.Remove(DeletedReservation);
                if (Reservation_Context.SaveChanges() > 0)
                {
                    MessageBox.Show($"Reservation with ID: {DeletedReservation.Id} was Deleted successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show($"Couldn't Delete reservation", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Res_PhoneNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ulong.TryParse(Res_PhoneNumber.Text, out ulong getphn))
            {
                string formatString = String.Format("{0:(000)000-0000}", getphn);
                Res_PhoneNumber.Text = formatString;

            }
            else
            {
                Res_PhoneNumber.Text = String.Empty;
            }
        }

        private void Res_FoodStatus_Checked(object sender, RoutedEventArgs e)
        {
            if (Res_FoodStatus.IsChecked == true)
            {
                Res_FoodStatus.Content = "Food/Supply: Complete";
                SelectedReservation.SupplyStatus = true;
            }
            else
            {
                Res_FoodStatus.Content = "Food/Supply status?";
                SelectedReservation.SupplyStatus = false;
            }
        }

        private void SendSMS()
        {
            string name = $"{SelectedReservation.FirstName} {SelectedReservation.LastName}";

            string end_num = SelectedReservation.CardNumber.Substring(SelectedReservation.CardNumber.Length - Math.Min(4, SelectedReservation.CardNumber.Length));

            if (Res_SendSMS.IsChecked == true)
            {
                string buildMesage = $"Hello {name}! Your unique ID#{SelectedReservation.Id} Total bill of ${SelectedReservation.TotalBill} is charged on your card # ending-{end_num}";

                MessageBox.Show(buildMesage, "SMS Sent", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
