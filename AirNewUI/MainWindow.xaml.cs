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

namespace AirNewUI
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void Button_Click(object sender, RoutedEventArgs e)   //async非同步
        {
            await this.ShowMessageAsync("This is the title", "Some message");   //MessageBox.Show
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //await this.ShowMessageAsync("This is the title", "Some message", MessageDialogStyle.AffirmativeAndNegative);
            // Confirm Box

            MessageDialogResult result = await this.ShowMessageAsync("This is the title", "Some message", MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Affirmative)
            {
                MessageBox.Show("OK跳轉畫面");
            }
            else
            {
                MessageBox.Show("Cancel");
            }
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var controller = await this.ShowProgressAsync("Please wait...", "Progress message");

        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LoginDialogData result = await this.ShowLoginAsync("Login", "Enter your password", new LoginDialogSettings {
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
    }
}
