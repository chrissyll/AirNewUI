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

        AirEntities dbContext = new AirEntities();

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bool loginSuccess = false;
            while (!loginSuccess)
            {
                LoginDialogData result = await this.ShowLoginAsync("Login", "Enter your password",
                   new LoginDialogSettings
                   {
                       ColorScheme = this.MetroDialogOptions.ColorScheme,
                       RememberCheckBoxVisibility = Visibility.Visible,
                       EnablePasswordPreview = true,
                       //UsernameWatermark = "aaa"
                   });

                if (result == null)
                {
                    MessageBox.Show("請輸入帳號密碼");
                    continue;
                }
                else
                {
                    var res = dbContext.Members.AsEnumerable().FirstOrDefault(x =>
                                x.Member_Account == result.Username && 
                                x.Member_Password == result.Password);

                    if (res != null)
                    {
                        MessageBox.Show("登入成功");
                        loginSuccess = true;
                    }
                    else
                    {
                        MessageBox.Show("帳號或密碼不正確");
                    }
                }
            }
        }

    }
}
