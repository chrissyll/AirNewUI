using AirTicket;
using AirTicket.Utilities;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class RegisterUserControl
    {
        MetroWindow window;
        AirEntities dbContext = new AirEntities();

        public RegisterUserControl()
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

            var controller = await window.ShowProgressAsync("Please wait...", "Register User", settings: mySettings);
            controller.SetIndeterminate();

            ErrorMessage.Content = "帳號或密碼不正確";

            await Task.Delay(2000);
            await controller.CloseAsync();
        }

        private void LoginTab_Click(object sender, RoutedEventArgs e)
        {
            ((LogInWindow)window).Tabs.SelectedIndex = 0;
        }

        private void phone_txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var txtOld = phone_txt.Text;
            var txtNew = e.Text;
            if (!Regex.IsMatch(txtNew, "[0-9]"))
            {
                e.Handled = true; // 敲不下去
            }
            if (txtOld.Length == 10)
            {
                e.Handled = true; // 敲不下去
            }
        }

        private async void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {

            if (firstname_txt.Text == "" || lastname_txt.Text == ""
                || password_txt.Password == "" || phone_txt.Text == ""
                || email_txt.Text == "" || GenderCombo.SelectedIndex==-1)
            {
                MessageBox.Show("* 資料未填寫完成");
                return;
            }

            string FirstName = this.firstname_txt.Text;
            string LastName = this.lastname_txt.Text;
            string Password = this.password_txt.Password;   //***
            string Phone = this.phone_txt.Text;
            string Email = this.email_txt.Text;

            //Password = HashPasswordForStoringInConfigFile(Password + salt, "sha1");


            Member newMember = new Member();
            newMember.Member_En_FirstName = FirstName.ToUpper();
            newMember.Member_En_LastName = LastName.ToUpper();
            newMember.Member_Password = Password;   //***
            newMember.Member_Phone = Phone;

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");    //判斷是否為正確的e-mail
            Match match = regex.Match(Email);
            if (match.Success)
            {
                newMember.Member_Account = Email;
            }
            else
            {
                MessageBox.Show("請輸入正確的e-mail");
                return;
            }

            if (GenderCombo.SelectedIndex == 0)
            {
                newMember.Member_Gender = "男";
            }
            else if (GenderCombo.SelectedIndex == 1)
            {
                newMember.Member_Gender = "女";
            }
            else
            {
                MessageBox.Show("請選擇性別");
                return;     //就不會往下走
            }

            var isEmailExist = dbContext.Members.Any(x => x.Member_Account == Email);   //用any判斷email是否存在，無論大小寫
            if (isEmailExist)
            {
                MessageBox.Show("此帳號已有人註冊");
                return;
            }

            Random r = new Random();
            int passcode = 1234;
            //passcode = r.Next(1000, 9999);
            //var sendResult = await Tools.SendSMS(Phone, passcode.ToString());     //寄手機簡訊

            string result = "";
            //int firstTime = 0;
            bool IsFirstTime = true;
            //while (passcode.ToString() != result)
            //{
            //    if (firstTime == 0)
            //    {
            //        result = await Tools.loginWindow.ShowInputAsync("已傳送4位數驗證碼!", "請輸入: ");
            //    }
            //    else
            //    {
            //        result = await Tools.loginWindow.ShowInputAsync("驗證碼錯誤!", "請重新輸入: ");
            //    }
            //    firstTime++;
            //}
            while (passcode.ToString() != result)
            {
                if (IsFirstTime)
                {
                    result = await Tools.loginWindow.ShowInputAsync("已傳送4位數驗證碼!", "請輸入: ");
                }
                else
                {
                    result = await Tools.loginWindow.ShowInputAsync("驗證碼錯誤!", "請重新輸入: ");
                }
                IsFirstTime = false;
            }

            //var result = await Tools.loginWindow.ShowInputAsync("已傳送4位數驗證碼!", "請輸入: ");
            //if (result == null)
            //{
            //    return;
            //}
            //if (passcode.ToString() != result)
            //{
            //    var result2 = await Tools.loginWindow.ShowInputAsync("已傳送4位數驗證碼!", "請輸入: ");
            //    if (result2 == null)
            //    {
            //        return;
            //    }
            //    if (passcode.ToString() != result2)
            //    {
            //        var result2 = await Tools.loginWindow.ShowInputAsync("已傳送4位數驗證碼!", "請輸入: ");
            //        if (result2 == null)
            //        {
            //            return;
            //        }
            //    }

            ProgressDialogController controller = await Tools.loginWindow.ShowProgressAsync("AirTicket Connection", "loading......");
            controller.SetIndeterminate();
            await Task.Delay(2000);
            await controller.CloseAsync();

            dbContext.Members.Add(newMember);
            dbContext.SaveChanges();

            Tools.SendEmail(Email);

            MessageBox.Show("加入成功");

            ((LogInWindow)window).Tabs.SelectedIndex = 0;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            firstname_txt.Text = "Wu";
            lastname_txt.Text = "Wu";
            password_txt.Password = "547";
            phone_txt.Text = "0989120120";
            email_txt.Text = "jackywu547@gmail.com";

        }

        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Text == "" || box.Text == null)     //另一個方法string.IsNullOrWhiteSpace(box.Text)
            {
                box.BorderBrush = Brushes.Red;
            }
            else
            {
                box.BorderBrush = Brushes.LightGray;
            }
        }

        private void cmb_LostFocus(object sender, RoutedEventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            if (box.SelectedIndex == -1)
            {
                box.BorderBrush = Brushes.Red;
            }
            else
            {
                box.BorderBrush = Brushes.LightGray;
            }
        }

        private void pwd_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox box = (PasswordBox)sender;
            if (box.Password == "" || box.Password == null)
            {
                box.BorderBrush = Brushes.Red;
            }
            else
            {
                box.BorderBrush = Brushes.LightGray;
            }
        }
    }
}
