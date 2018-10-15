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

namespace AirTicket
{
    /// <summary>
    /// UserControlFlight.xaml 的互動邏輯
    /// </summary>
    public partial class UserControlFlight : UserControl
    {
        public event EventHandler AddChild1;
        public event EventHandler AddChild2;

        public UserControlFlight()
        {
            InitializeComponent();

            button1.Click += delegate (object sender, RoutedEventArgs e)
            {
                  if(AddChild1!=null)
                  { AddChild1(this, EventArgs.Empty); }
              };

            button2.Click += delegate (object sender, RoutedEventArgs e)
            {
                if (AddChild2 != null)
                { AddChild2(this, EventArgs.Empty); }
            };




        }

        

        //航班
        public string Flight
        {
            set
            {
                this.label1.Content = value;
            }
        }
        //出發地
        public string Departure_Airport
        {
            set
            {
                this.Departure_Airport_lab.Content = value;
            }
        }
        //出發時間
        public DateTime Departure_Time
        {
            set
            {
                this.Time1.Content = value;
            }
        }
        //飛行時間
        public DateTime Duration_Time
        {
            set
            {
                this.Duration.Content = value;
            }
        }
        //抵達地
        public string Arrival_Airport
        {
            set
            {
                this.Arrival_Airport_lab.Content = value;
            }
        }
        //抵達時間
        public DateTime Arrival_Time
        {
            set
            {
                this.Time2.Content = value;
            }
        }

       
    }

}
