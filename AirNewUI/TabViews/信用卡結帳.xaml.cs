using AirTicket.Utilities;
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

namespace AirTicket
{
    /// <summary>
    /// 信用卡結帳.xaml 的互動邏輯
    /// </summary>
    public partial class 信用卡結帳
    {
        internal 旅客資料填寫 getPassenger;
       
        public string comboxCard;
        public 信用卡結帳()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.MasterCard.IsChecked==true)
            {
                comboxCard = "MasterCard";                                
            }
            else if(this.Visa.IsChecked==true)
            {
                comboxCard = "Visa";
            }
            else if(this.Amex.IsChecked==true)
            {
                comboxCard = "Amex";
            }
            else
            {
                MessageBox.Show("請選擇信用卡號");
            }

            機票訂單確認 oc = new 機票訂單確認();
            oc.getCard = this;
            Tools.GetIconItem("SearchFlightTab").Tag = oc;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.name1.Text = "吳世祺";
            this.CreadeCardId.Text = "4000-1234-5678-9010";
            this.Validthur.Text = "20/12";
            this.Cvv.Text = "888";
        }
    }
}
