using AirNewUI;
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
    /// 機票訂單.xaml 的互動邏輯
    /// </summary>
    public partial class 機票訂單
    {
        AirEntities DbContext = new AirEntities();

        CollectionViewSource orderViewSource;
        public 機票訂單()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DbContext.Orders.AsEnumerable().ToList();
            orderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource")));
            // 透過設定 CollectionViewSource.Source 屬性載入資料: 
            // orderViewSource.Source = [泛用資料來源]
            orderViewSource.Source = DbContext.Orders.Local;

            var result = from o in this.DbContext.Orders
                         join a in this.DbContext.Airlines on o.Airline_ID equals a.Airline_ID
                         join f in this.DbContext.Flights on o.Flight_ID equals f.Flight_ID
                         join ap in this.DbContext.Airports on o.Arrival_Airport_ID equals ap.Airport_ID
                         join c in this.DbContext.Cabins on o.Cabin_ID equals c.Cabin_ID
                         //join p in this.DbContext.Passengers on o.Ticket_ID equals p.Ticket_ID                         
                         select new { 訂單編號 = o.Ticket_ID, 航空公司 = o.Airline.Airline_Name, 出發地 = o.Airport.Airport_Name, 目的地 = o.Airport1.Airport_Name, 艙等 = o.Cabin.Cabin_Name, 出發時間 = o.Departure_Time, 抵達時間 = o.Arrival_Time, 直飛或轉機 = o.NonStop,會員編號=o.Member_ID, 訂單日期 = o.Order_Time, 付款方式 = o.Payment/* ,乘客=p.Order.Ticket_ID*/ };
            this.DataGrid1.ItemsSource =result.ToList();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //todo 日期搜尋
            
            //DateTime Departure_Date = this.DatePicker1.SelectedDate.Value;
            string AirLineName = this.AirLineName.Text;

            //if (this.AirLineName.Text is null && this.DatePicker1.SelectedDate == null)
            //{
            //    MessageBox.Show("請輸入查詢航空公司或日期");
            //}
            //else if (this.AirLineName.Text == null && this.DatePicker1.SelectedDate != null)
            //{
            //    //查詢日期                
            //    this.orderViewSource.Source = this.DbContext.Orders.Where(o => o.Departure_Time == Departure_Date).ToList();

            //}
            //else if (this.AirLineName.Text != null && this.DatePicker1.SelectedDate == null)
            //{
            //    //查詢航空公司
            //    this.orderViewSource.Source = this.DbContext.Orders.Where(o => o.Airline.Airline_Name == AirLineName).ToList();
            //}
            //else
            //{
            //    this.orderViewSource.Source = this.DbContext.Orders.Where(o => o.Airline.Airline_Name == AirLineName && o.Departure_Time == Departure_Date).ToList();
            //}
            
            var result = from o in this.DbContext.Orders
                         join a in this.DbContext.Airlines on o.Airline_ID equals a.Airline_ID
                         join f in this.DbContext.Flights on o.Flight_ID equals f.Flight_ID
                         join ap in this.DbContext.Airports on o.Arrival_Airport_ID equals ap.Airport_ID
                         join c in this.DbContext.Cabins on o.Cabin_ID equals c.Cabin_ID
                         //where o.Departure_Time.Value >= Departure_Date 
                         where o.Airline.Airline_Name == AirLineName
                         select new { 訂單編號 = o.Ticket_ID, 航空公司 = o.Airline.Airline_Name, 出發地 = o.Airport.Airport_Name, 目的地 = o.Airport1.Airport_Name, 艙等 = o.Cabin.Cabin_Name, 出發時間 = o.Departure_Time, 抵達時間 = o.Arrival_Time, 直飛或轉機 = o.NonStop, 會員編號 = o.Member_ID, 訂單日期 = o.Order_Time, 付款方式 = o.Payment/* ,乘客=p.Order.Ticket_ID*/ };
            this.DataGrid1.ItemsSource = result.ToList();

        }
    }
}
