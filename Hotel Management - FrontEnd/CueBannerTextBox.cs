using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Hotel_Management___FrontEnd
{
    public class CueBannerTextBox : TextBox
    {
        public static readonly DependencyProperty CueBannerProperty =
            DependencyProperty.Register("CueBanner", typeof(string), typeof(CueBannerTextBox), new UIPropertyMetadata(string.Empty));

        public string CueBanner
        {
            get { return (string)GetValue(CueBannerProperty); }
            set { SetValue(CueBannerProperty, value); }
        }

        static CueBannerTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CueBannerTextBox), new FrameworkPropertyMetadata(typeof(CueBannerTextBox)));
        }
    }

}
