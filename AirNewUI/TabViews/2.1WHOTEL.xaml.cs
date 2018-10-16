using AirTicket.Utilities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirTicket
{
    /// <summary>
    /// _9.xaml 的互動邏輯
    /// </summary>
    public partial class WHotel : UserControl
    {
        public WHotel()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            Window4 W3 = new Window4();
            Tools.GetIconItem("SearchHotelTab").Tag = W3;


        }
    }
}
