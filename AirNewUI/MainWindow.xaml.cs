using AirTicket.TabViews;
using AirTicket.Utilities;
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

            txbLoginEntity.Text = Tools.UserName;
            string appLocation = AppDomain.CurrentDomain.BaseDirectory;
            empPhotoIcon.Source = 
                new BitmapImage(new Uri(appLocation.Replace(@"\bin\Debug\", @"\images\user0.png")));
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
        private async void BtnLoginout_OnClick(object sender, RoutedEventArgs e)
        {
            var mySettings = new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true
            };

            var controller = await this.ShowProgressAsync("Please wait...", "loading", settings: mySettings);
            controller.SetIndeterminate();

            await Task.Delay(1500);
            await controller.CloseAsync();

            txbLoginEntity.Text = "未登入";
            MessageBox.Show("確認登出");

            //LogInWindow loginWindow = new LogInWindow();
            //loginWindow.Show();
            //this.Hide();
            Tools.mainWindow.Hide();
            Tools.loginWindow.Show();
        }
    }
}
