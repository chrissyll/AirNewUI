using AirTicket;
using AirTicket.TabViews;
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
    /// 機票訂單確認.xaml 的互動邏輯
    /// </summary>
    public partial class 機票訂單確認
    {
        internal 信用卡結帳 getCard;
        public 機票訂單確認()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.listboxflight.Content = "航空公司 :"+this.getCard.getPassenger.getTicket.flight ;                       
            this.listboxdeparture_airport_name.Content = "出發地 :台北桃園(TPE)";
            this.listboxtime1.Content = "出發時間 :" + this.getCard.getPassenger.getTicket.time1;
            this.listboxduration.Content = "飛行時間 :" + this.getCard.getPassenger.getTicket.duration;
            this.listboxarrival_airport_name.Content = "目的地 :" + this.getCard.getPassenger.getTicket.arrival_airport_name;
            this.listboxtime2.Content = "抵達時間 :" + this.getCard.getPassenger.getTicket.time2;
            this.listboxcabin.Content = "艙等 :" + this.getCard.getPassenger.getTicket.cabin;
            this.listboxnum.Content = "乘客數 :" + this.getCard.getPassenger.getTicket.num;
            this.listboxprice.Content = "價錢 : NT "+ this.getCard.getPassenger.getTicket.price +"/位" ;


            for (int i = 0; i < getCard.getPassenger.getTicket.num; i++)
            {
                UserControlPassenger ucp1 = new UserControlPassenger();
                ucp1.Passanger1.Content = "乘客 " + (i + 1);
                ucp1.PassPortid.Text = this.getCard.getPassenger.psg[i].PassPortid.Text;
                ucp1.Firstname.Text = this.getCard.getPassenger.psg[i].Firstname.Text;
                ucp1.Lastname.Text = this.getCard.getPassenger.psg[i].Lastname.Text;
                ucp1.combox1.Text = this.getCard.getPassenger.psg[i].combox1.Text;
                ucp1.Mybirthday.Text = this.getCard.getPassenger.psg[i].Mybirthday.Text;
                ucp1.Passportenddate.Text = this.getCard.getPassenger.psg[i].Passportenddate.Text;
                this.stackpanel1.Children.Add(ucp1);    
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            save();
            MessageBox.Show("訂單成功");
            //this.Close();
            
        }

        private void save()
        {
            AirEntities DbContext = new AirEntities();

            Order order1 = new Order();//訂單資料表

            var airline_id = (from o in DbContext.Airlines
                     where o.Airline_Name == this.getCard.getPassenger.getTicket.flight
                     select o.Airline_ID).FirstOrDefault();

            var departure_airport_id = (from o in DbContext.Airports
                                       where o.Airport_Name == "台北桃園(TPE)"
                                       select o.Airport_ID).FirstOrDefault();

            var arrival_airport_id = (from o in DbContext.Airports
                                     where o.Airport_Name == this.getCard.getPassenger.getTicket.arrival_airport_name
                                     select o.Airport_ID).FirstOrDefault();

            var cabin = (from o in DbContext.Cabins
                        where o.Cabin_Name == this.getCard.getPassenger.getTicket.cabin
                        select o.Cabin_ID).FirstOrDefault();

            //string user_account = LoginUserControl.UserName;
            var user_id = (from o in DbContext.Members
                           where o.Member_Account == LoginUserControl.UserName
                           select o.Member_ID).FirstOrDefault();


            DateTime parsedDT = DateTime.Parse(this.getCard.getPassenger.getTicket.time1);
            DateTime parsedAT = DateTime.Parse(this.getCard.getPassenger.getTicket.time2);

            order1.Flight_ID = Int32.Parse(this.getCard.getPassenger.getTicket.Tag.ToString());
            order1.Airline_ID = airline_id;
            order1.Departure_Time = parsedDT;
            order1.Departure_Airport_ID = departure_airport_id;
            order1.Arrival_Airport_ID = arrival_airport_id;
            order1.Arrival_Time = parsedAT;
            order1.Cabin_ID = cabin;
            
            order1.Member_ID = user_id;
            order1.Payment = this.getCard.comboxCard;
            order1.NonStop = "直飛";
            order1.Order_Time = DateTime.Now;

            DbContext.Orders.Add(order1);


            var ticketid = (from o in DbContext.Orders
                            select o.Ticket_ID).ToArray().LastOrDefault();

            Passenger passenger1 = new Passenger(); //乘客資料表
            
            //將乘客資料存回資料庫
            for (int i = 0; i < getCard.getPassenger.getTicket.num; i++)
            {
                //字串轉成日期
                DateTime parsedBD = DateTime.Parse(this.getCard.getPassenger.psg[i].Mybirthday.Text);
                DateTime parsedDE = DateTime.Parse(this.getCard.getPassenger.psg[i].Passportenddate.Text);

                passenger1.Ticket_ID = ticketid+1;
                passenger1.Passenger_En_FirstName = this.getCard.getPassenger.psg[i].Firstname.Text;
                passenger1.Passenger_En_LastName = this.getCard.getPassenger.psg[i].Lastname.Text;
                passenger1.Passenger_Gender= this.getCard.getPassenger.psg[i].combox1.Text;
                passenger1.Passenger_Passport= this.getCard.getPassenger.psg[i].PassPortid.Text;
                passenger1.Death_Of_Birth= parsedBD;
                passenger1.Death_Of_Expiry = parsedDE;

                DbContext.Passengers.Add(passenger1);
            }

            try
            {
                DbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
