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

namespace AirNewUI.TabViews
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl
    {
        MetroWindow window;
        public LoginUserControl()
        {
            InitializeComponent();
            window = (Application.Current.MainWindow as MetroWindow);
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var mySettings = new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true
            };

            var controller = await window.ShowProgressAsync("Please wait...", "Authenticating User", settings: mySettings);
            controller.SetIndeterminate();

            await Task.Delay(2500);
            await controller.CloseAsync();

            ErrorMessage.Content = "* 帳號或密碼不正確";
        }

        private void ReisterTab_Click(object sender, RoutedEventArgs e)
        {
            ((LogInWindow)window).Tabs.SelectedIndex = 1;
        }
    }
}
