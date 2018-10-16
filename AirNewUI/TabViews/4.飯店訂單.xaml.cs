using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;




namespace AirTicket
{
    /// <summary>
    /// 飯店訂單.xaml 的互動邏輯
    /// </summary>
    public partial class 飯店訂單 
    {
        public 飯店訂單()
        {
            InitializeComponent();            
        }

        AirEntities dbcontext = new AirEntities();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        
            var q = from o in dbcontext.HotelOrders.AsEnumerable()
                     join Od in this.dbcontext.Hotel_Order_Detail
                     on o.Order_ID equals Od.Order__ID

                    select  new {
                       
                        旅館名稱 =o.Hotel_Name,
                        訂單編號 = o.Order_ID,
                        訂單時間 = o.Order_Date?.ToShortDateString(),
                        價格 =   o.Total_Price,
                        人數 = o.Living_Number_of_people,
                        房間種類 = Od.Room_Category,
                        房間數量 = Od.Room_Quantity,
                        附餐 = Od.Food
                    };
          
            this.datagrid.ItemsSource = q.ToList();

         
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int Order_ID = Convert.ToInt32(this.textbox1.Text);

            
            var a = dbcontext.HotelOrders.First(s => s.Order_ID == Order_ID);
            dbcontext.HotelOrders.Remove(a);
            dbcontext.SaveChanges();
            this.datagrid.ItemsSource = dbcontext.HotelOrders.ToList();

        }

        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
