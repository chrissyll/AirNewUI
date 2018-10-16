using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirTicket.Utilities
{
    class Tools
    {
        public static MetroWindow loginWindow;
        public static MetroWindow mainWindow;
        public static string UserName;

        public static MetroWindow GetWindow()
        {
            return (MetroWindow)Application.Current.MainWindow;
        }

        public static HamburgerMenuIconItem GetIconItem(string hamburgerIconItemName)
        {
            return (HamburgerMenuIconItem)GetWindow().FindName(hamburgerIconItemName);
        }


        public async static Task<string> SendSMS(string phoneNumber, string content)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, $@"https://www.rohimchou.com/wpf/api/sendsms?mobilenumber={phoneNumber}&content={content}");
                HttpResponseMessage httpResponse = await httpClient.SendAsync(httpRequest);
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }

        public static void SendEmail(string Email)
        {
            #region SendMail
            MailMessage msg = new MailMessage();
            //收件者，以逗號分隔不同收件者 ex "test@gmail.com,test2@gmail.com"
            //msg.To.Add(string.Join("email", MailList.ToArray()));
            msg.From = new MailAddress("msit120120@gmail.com", "AirTicket Company", Encoding.UTF8);
            msg.To.Add(Email);
            //郵件標題 
            msg.Subject = "[Airticket] Confirm E-mail Address";
            //郵件標題編碼  
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            //郵件內容
            msg.Body = "<p style=\"color:blue\">Welcome !!</p><p>Thanks for signing up with<strong> AirTicket!</strong></p>";
            msg.IsBodyHtml = true;
            msg.BodyEncoding = Encoding.UTF8;       //郵件內容編碼 
            msg.Priority = MailPriority.Normal;     //郵件優先級 
                                                    //建立 SmtpClient 物件 並設定 Gmail的smtp主機及Port 
            #region 其它 Host
            /*
             *  outlook.com smtp.live.com port:25
             *  yahoo smtp.mail.yahoo.com.tw port:465
            */
            #endregion
            SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);
            //設定你的帳號密碼
            MySmtp.Credentials = new System.Net.NetworkCredential("msit120120@gmail.com", "mmsit120");  //正常要加密
            //Gmial 的 smtp 使用 SSL
            MySmtp.EnableSsl = true;
            MySmtp.Send(msg);
            //啟用 低安全性應用程式存取權https://myaccount.google.com/lesssecureapps
            #endregion
        }

        //public void SayHi() { }
        //public async Task SayHiAsync() { }

        //public string GetName() { return ""; }
        //public async Task<string> GetNameAsync() { return ""; }

        //public int GetMax() { return 0; }
        //public async Task<int> GetMaxAsync() { return 0; }
    }
}
