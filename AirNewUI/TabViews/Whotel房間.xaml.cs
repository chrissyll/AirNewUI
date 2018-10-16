using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// _3.xaml 的互動邏輯
    /// </summary>
    public partial class _3 : Window
    {
        public _3()
        {
            InitializeComponent();
        }


        HotelEntities2 dbcontext = new HotelEntities2();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //搜尋最後一筆訂單編號
            var q = (from o in dbcontext.HotelOrders
                     select o.Order_ID).ToArray().LastOrDefault();

         int i =1;
            this.dbcontext.HotelOrders.Local.
            Add (
            new HotelOrder
            {
                Hotel_Name= "W HOTEL" ,
                Hotel_ID = i,
                Living_Number_of_people = 2,
                Total_Price = 10280,
                Order_Date = DateTime.Now
            });
            this.dbcontext.Hotel_Order_Detail.Local.
            Add(
            new Hotel_Order_Detail
            {
                Order__ID = q+1 ,
                Room_Quantity = 1,
                Room_Category = "奇妙特大號床間",
                Food=true
            });
            try
            {
               dbcontext.SaveChanges();

                MessageBox.Show("訂房成功");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            飯店訂單 W3 = new 飯店訂單();
            W3.Show();
            this.Close();
        }
    }
}
