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

namespace AirTicket.TabViews
{
    /// <summary>
    /// Interaction logic for LoginUserControl.xaml
    /// </summary>
    public partial class LoginUserControl
    {
        MetroWindow window;
        AirEntities dbContext = new AirEntities();

        public LoginUserControl()
        {
            InitializeComponent();
            window = (Application.Current.MainWindow as MetroWindow);
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (email_txt.Text == "")
            {
                email_txt.BorderBrush = Brushes.Red;
            }
            else
            {
                email_txt.BorderBrush = Brushes.LightGray;  //不是預設值
            }
            if (password_txt.Password == "")
            {
                password_txt.BorderBrush = Brushes.Red;
            }
            else
            {
                password_txt.BorderBrush = Brushes.LightGray;
            }

            var mySettings = new MetroDialogSettings()
            {
                AnimateShow = true,
                AnimateHide = true
            };

            var controller = await window.ShowProgressAsync("Please wait...", "Authenticating User", settings: mySettings);
            controller.SetIndeterminate();

            var result = dbContext.Members.AsEnumerable().FirstOrDefault(x =>
           x.Member_Account == email_txt.Text && x.Member_Password == password_txt.Password);

            await Task.Delay(2200);
            await controller.CloseAsync();

            if (result != null)
            {
                MessageBox.Show("登入成功");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                window.Hide();
            }
            else
            {
                ErrorMessage.Content = "* 帳號或密碼不正確";
                password_txt.Clear();
            }
        }

        private async void ReisterTab_Click(object sender, RoutedEventArgs e)
        {
            var disclaimer = @"我們的擔保與免責聲明

我們會以商業上合理的技術與注意程度提供「服務」，希望您會盡情使用。但關於「服務」，有些事情我們不予保證。

除本條款或額外條款中明示規定者外，AirTicket 或其供應商或經銷商均不對「服務」做出任何特定保證。例如，我們不會就「服務」中的內容、「服務」之特定功能及其可靠性、可用性和符合您的需求的能力，做出任何承諾。我們僅以「現狀」提供「服務」。

部分司法管轄區會規定應提供特定擔保，例如對適銷性、特殊用途適用性及未侵權之默示擔保。凡法律准許時，我們均排除一切擔保責任。";
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Agree",
                NegativeButtonText = "Cancel"
            };

            MessageDialogResult result = await window.ShowMessageAsync(
                "Hello!", 
                disclaimer,
                MessageDialogStyle.AffirmativeAndNegative, mySettings);

            if (result == MessageDialogResult.Affirmative)
            {
                ((LogInWindow)window).Tabs.SelectedIndex = 1;
            }
        }

        private void Demo1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            window.Hide();
        }
    }
}
