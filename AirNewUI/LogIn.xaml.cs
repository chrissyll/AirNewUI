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
using System.Windows.Shapes;

namespace AirNewUI
{
    /// <summary>
    /// LogIn.xaml 的互動邏輯
    /// </summary>
    public partial class LogIn
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginDialogData result = await this.ShowLoginAsync("Login", "Enter your password", new LoginDialogSettings
            {
                ColorScheme = this.MetroDialogOptions.ColorScheme,
                RememberCheckBoxVisibility = Visibility.Visible,
                EnablePasswordPreview = true,
                //UsernameWatermark = "aaa"
            });
            if (result == null)
            {
                // User pressed cancel
            }
            else
            {
                //MessageDialogResult messageResult = await this.ShowMessageAsync("Authentication Information", String.Format("Username: {0}\nPassword: {1}\nShouldRemember: {2}", result.Username, result.Password, result.ShouldRemember));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
