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

namespace Hotel_Management___FrontEnd
{
    /// <summary>
    /// Interaction logic for FinalizeBill.xaml
    /// </summary>
    public partial class FinalizeBill : Window
    {

        public int TotalAmount { get; set; } = 0;
        public int FoodBill { get; set; } = 0;

        public double FinalTotalBill { get; set; } = 0.0;
        public string PaymentCardType { get; set; }

        public FinalizeBill()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CueBannerTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ulong.TryParse(CC_Number.Text, out ulong getphn))
            {
                string formatString = String.Format("{0:0000-0000-0000-0000}", getphn);
                CC_Number.Text = formatString;
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
