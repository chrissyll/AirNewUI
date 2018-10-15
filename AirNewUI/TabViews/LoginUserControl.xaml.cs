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

            if (result != null)
            {
                MessageBox.Show("登入成功");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                window.Hide();
                Application.Current.MainWindow = mainWindow;
            }
            else
            {
                ErrorMessage.Content = "* 帳號或密碼不正確";
                password_txt.Clear();
            }
        }

        private async void ReisterTab_Click(object sender, RoutedEventArgs e)
        {
            var disclaimer = @"Liability for our Services
When permitted by law, AirTicket, and AirTicket’s suppliers and distributors, will not be responsible for lost profits, revenues, or data, financial losses or indirect, special, consequential, exemplary, or punitive damages.

To the extent permitted by law, the total liability of AirTicket, and its suppliers and distributors, for any claims under these terms, including for any implied warranties, is limited to the amount you paid us to use the Services (or, if we choose, to supplying you the Services again).

In all cases, AirTicket, and its suppliers and distributors, will not be liable for any loss or damage that is not reasonably foreseeable.

We recognize that in some countries, you might have legal rights as a consumer. If you are using the Services for a personal purpose, then nothing in these terms or any additional terms limits any consumer legal rights which may not be waived by contract.";

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
            Application.Current.MainWindow = mainWindow;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            email_txt.Text = "547@gmail.com";
            password_txt.Password = "547";
        }
    }
}
