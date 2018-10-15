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
    /// 旅客資料填寫.xaml 的互動邏輯
    /// </summary>
    public partial class 旅客資料填寫
    {
        
        internal 搜尋機票 getTicket;
        internal List<UserControlPassenger> psg = new List<UserControlPassenger>();
        public 旅客資料填寫()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int num1 = getTicket.num;
            for (int i = 0; i < num1; i++)
            {
                UserControlPassenger ucp = new UserControlPassenger();
                ucp.Passanger1.Content = "乘客 " + (i + 1);
                this.stackpanel1.Children.Add(ucp);
                                              
            }
            
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //從 stackpanel1.Children去搜尋使用者控制項個數
            for (int i = 0; i < stackpanel1.Children.Count; i++)
            {
                //從 stackpanel1.Children去搜尋使用者控制項個數
                UserControlPassenger ucp = (UserControlPassenger) stackpanel1.Children[i];
                psg.Add(ucp);
            }



            信用卡結帳 cr = new 信用卡結帳();
            cr.getPassenger = this;
            //cr.Show();
        }
    }
}
