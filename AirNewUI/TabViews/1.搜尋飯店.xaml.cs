using MahApps.Metro.Controls;
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
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class Window1 
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MetroWindow window = (MetroWindow)Application.Current.MainWindow;
            HamburgerMenuIconItem iconItem = (HamburgerMenuIconItem)window.FindName("SearchHotelTab");
            飯店類別 W = new 飯店類別();
            iconItem.Tag = W;
            

        }

        private void DATE2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
            DateTime date1 = new DateTime(this.DATE1.SelectedDate.Value.Year,this.DATE1.SelectedDate.Value.Month,this.DATE1.SelectedDate.Value.Day);
            DateTime date2 = new DateTime(this.DATE2.SelectedDate.Value.Year, this.DATE2.SelectedDate.Value.Month, this.DATE2.SelectedDate.Value.Day);
            TimeSpan s = DATE2.SelectedDate.Value - DATE1.SelectedDate.Value;
            labe1.Content = s.Days;
            
        }
    }
}
