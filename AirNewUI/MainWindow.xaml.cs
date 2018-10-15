using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
            this.BorderThickness = new Thickness(0);
            ThemeManager.ChangeAppStyle(this,
                ThemeManager.GetAccent("Steel"),
                ThemeManager.GetAppTheme("BaseLight"));

            txbLoginEntity.Text = "Chrissy";
            string appLocation = AppDomain.CurrentDomain.BaseDirectory;
            empPhotoIcon.Source = 
                new BitmapImage(new Uri(appLocation.Replace(@"\bin\Debug\", @"\images\Avatar1.png")));
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            HamburgerMenuControl.Content = e.InvokedItem;
        }

        //登出
        private void BtnLoginout_OnClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
