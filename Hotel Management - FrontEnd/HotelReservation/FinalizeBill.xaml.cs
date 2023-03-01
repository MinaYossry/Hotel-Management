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
using System.Windows.Shapes;
using System.Xml;

namespace Hotel_Management___FrontEnd
{
    /// <summary>
    /// Interaction logic for FinalizeBill.xaml
    /// </summary>
    public partial class FinalizeBill : Window
    {
        private List<string> PaymentTypes = new()
        {
            "Debit",
            "Credit"
        };


        private List<string> CardMonths = new()
        {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
        };

        private List<string> CardYears = new()
        {
                    "14",
                    "15",
                    "16",
                    "17",
                    "18",
                    "19",
                    "20",
                    "21",
                    "22",
                    "23",
                    "24",
                    "26",
        };
        public int TotalAmount { get; set; } = 0;
        public int FoodBill { get; set; } = 0;

        public double FinalTotalBill { get; set; } = 0.0;
        public string PaymentCardType { get; set; }

        public FinalizeBill()
        {
            InitializeComponent();
            PaymentType.ItemsSource = PaymentTypes;
            CC_Month.ItemsSource = CardMonths;
            CC_Year.ItemsSource = CardYears;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AllDataIsValid())
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Must Enter All Data");
            }
        }

        private bool AllDataIsValid()
        {
            return CC_CVC.Text != "" && CC_Number.Text != ""
                && CC_Month.SelectedItem is not null
                && CC_Year.SelectedItem is not null
                && CC_Type.Content is not null;

        }

        private void CueBannerTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ulong.TryParse(CC_Number.Text, out ulong getphn))
            {
                string formatString = String.Format("{0:0000-0000-0000-0000}", getphn);
                CC_Number.Text = formatString;

                string firstDigit = CC_Number.Text.Substring(0, 1);
                switch (firstDigit)
                {
                    case "3":
                        CC_Type.Content = "AmericanExpress";
                        break;
                    case "4":
                        CC_Type.Content = "Visa";
                        break;
                    case "5":
                        CC_Type.Content = "MasterCard";
                        break;
                    case "6":
                        CC_Type.Content = "Discover";
                        break;
                    default:
                        CC_Type.Content = "Unknown";
                        break;
                }

            }
            else
            {
                CC_Number.Text = String.Empty;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double totalWithTax = TotalAmount * 0.07;
            double FinalTotal = TotalAmount + totalWithTax + FoodBill;

            Label_CurrentBill.Content = $"${TotalAmount, 2} USD";
            Label_FoodBill.Content = $"${FoodBill, 2} USD";
            Label_Tax.Content = $"${totalWithTax, 2} USD";
            Label_TotalBill.Content = $"${FinalTotal, 2} USD";

            FinalTotalBill = FinalTotal;
        }
    }
}
