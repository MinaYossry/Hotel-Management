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
    /// Interaction logic for ReservationPage.xaml
    /// </summary>
    public partial class ReservationPage : UserControl
    {
        public int TotalAmount { get; set; }
        public bool IsEditingReservation { get; set; }
        public bool IsEditClicked { get; set; }

        public string CC_PaymentType { get; set; }
        public string CC_CardNumber { get; set; }
        public string CC_ExpireMonth { get; set; }
        public string CC_ExpireYear { get; set; }
        public string CC_CardCVC { get; set; }

        private double FinalTotalAmount { get; set; } = 0.0;
        private string PaymentType { get; set; }
        private string PaymentCardNumber { get; set; }
        private string MM_YY_Of_Card { get; set; }
        private string CVC_Of_Card { get; set; }
        private string CardType { get; set; }

        public int FoodBill { get; set; }

        private int LunchCount { get; set; } = 0;
        private int BreakfastCount { get; set; } = 0;
        private int DinnerCount { get; set; } = 0;

        private bool Cleaning { get; set; }
        private bool Towels { get; set; }
        private bool SweatestSurprice { get; set; }

        public ReservationPage()
        {
            InitializeComponent();
            Res_EntryDate.DisplayDateStart = DateTime.Today;
            Res_DepartureDate.DisplayDateEnd = DateTime.Today.AddDays(1);
            
        }

        private void btn_FoodMenu_Click(object sender, RoutedEventArgs e)
        {
            FoodMenu foodMenu = new FoodMenu();

            if (IsEditingReservation)
            {
                if (BreakfastCount > 0)
                {
                    foodMenu.Check_Breakfast.IsChecked = true;
                    foodMenu.text_BreakfastCount.Text = BreakfastCount.ToString();
                }

                if (LunchCount > 0)
                {
                    foodMenu.Check_Lunch.IsChecked = true;
                    foodMenu.text_LunchCount.Text = LunchCount.ToString();
                }

                if (DinnerCount > 0)
                {
                    foodMenu.Check_Dinner.IsChecked = true;
                    foodMenu.text_DinnerCount.Text = DinnerCount.ToString();
                }

                foodMenu.Check_Cleaning.IsChecked = Cleaning;
                foodMenu.Check_Towels.IsChecked = Towels;
                foodMenu.Check_SweetestSurprise.IsChecked = SweatestSurprice;
            }

            if (foodMenu.ShowDialog() == true)
            {

                BreakfastCount = foodMenu.BreafastCount;
                LunchCount = foodMenu.LunchCount;
                DinnerCount = foodMenu.DinnerCount;

                Cleaning = foodMenu.IsCleaning;
                Towels = foodMenu.IsTowels;
                SweatestSurprice = foodMenu.IsSweatestSurprise;

                FoodBill = foodMenu.TotalFoodBill;
                MessageBox.Show($"{foodMenu.TotalFoodBill}");
            }
        }

        private void btn_FinalizeBill_Click(object sender, RoutedEventArgs e)
        {
            if (BreakfastCount == 0 && LunchCount == 0 && DinnerCount == 0 && !Cleaning && !Towels && !SweatestSurprice) 
            {
                Res_FoodStatus.IsChecked = true;
            }
            btn_Update.IsEnabled = true;

            if (CalculateBill())
            {
                FinalizeBill finalizeBill = new FinalizeBill();
                finalizeBill.TotalAmount = TotalAmount;
                finalizeBill.FoodBill = FoodBill;

                if(IsEditingReservation)
                {
                    finalizeBill.PaymentType.SelectedItem = PaymentType;
                    finalizeBill.CC_Number.Text = CC_CardNumber;
                    finalizeBill.CC_Month.SelectedItem = CC_ExpireMonth;
                    finalizeBill.CC_Year.SelectedItem = CC_ExpireYear;
                    finalizeBill.CC_CVC.Text = CC_CardCVC;
                }


                if (finalizeBill.ShowDialog() == true)
                {
                    FinalTotalAmount = finalizeBill.FinalTotalBill;
                    PaymentType = finalizeBill.PaymentType.SelectedItem.ToString();
                    PaymentCardNumber = finalizeBill.CC_Number.Text;
                    MM_YY_Of_Card = $"{finalizeBill.CC_Month.SelectedItem}/{finalizeBill.CC_Year.SelectedItem}";
                    CVC_Of_Card = finalizeBill.CC_CVC.Text;
                    CardType = finalizeBill.CC_Type.Content.ToString();
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
            switch (Res_RoomType?.Text)
            {
                case "Single":
                    TotalAmount = 149;
                    Res_Floor.SelectedItem = "1";
                    break;
                case "Double":
                    TotalAmount = 299;
                    Res_Floor.SelectedItem = "2";
                    break;
                case "Twin":
                    TotalAmount = 349;
                    Res_Floor.SelectedItem = "3";
                    break;
                case "Dublex":
                    TotalAmount = 399;
                    Res_Floor.SelectedItem = "4";
                    break;
                case "Suite":
                    TotalAmount = 499;
                    Res_Floor.SelectedItem = "5";
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

    }
}
