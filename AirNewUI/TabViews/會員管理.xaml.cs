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

namespace AirTicket
{
    /// <summary>
    /// 會員管理.xaml 的互動邏輯
    /// </summary>
    public partial class 會員管理
    {
        public 會員管理()
        {
            InitializeComponent();
            //datagrid1.FrozenColumnCount = 1;
        }

        AirEntities dbContext = new AirEntities();
        // 會員管理
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var result = dbContext.Members.Where(x => x.Member_Account == txt.Text ||
            //x.Member_Ch_FirstName == txt.Text || x.Member_Ch_LastName == txt.Text ||
            //x.Member_En_FirstName == txt.Text || x.Member_En_LastName == txt.Text ||
            //x.Member_Gender == txt.Text || x.Member_Phone == txt.Text);
            var result = dbContext.Members.AsEnumerable().Where(x => x.Member_Account == email_txt.Text).Select(x => new
            {
                E_mail = x.Member_Account,
                英文_姓 = x.Member_En_FirstName,
                英文_名 = x.Member_En_LastName,
                中文_姓 = x.Member_Ch_FirstName,
                中文_名 = x.Member_Ch_LastName,
                性別 = x.Member_Gender,
                生日 = x.Date_Of_Birth?.ToShortDateString(),
                手機 = x.Member_Phone
            }); 
            datagrid1.ItemsSource = result.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var res = dbContext.Members.FirstOrDefault(x => x.Member_Account == email_txt.Text);
            if (res != null)
            {
                res.Member_Ch_FirstName = cnFirst_txt.Text;
                res.Member_Ch_LastName = cnLast_txt.Text;
                res.Date_Of_Birth = birth_date.SelectedDate;    //會顯示時間
                res.Member_Phone = phone_txt.Text;
                dbContext.SaveChanges();
                MessageBox.Show("更新成功");
            }
            else
            {
                email_txt.BorderBrush = Brushes.Red;
                MessageBox.Show("請填寫正確E-Mail");
            }
        }

        private void datagrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //datagrid1.FrozenColumnCount = 1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var res = dbContext.Members.First(x => x.Member_Account == email_txt.Text);
                dbContext.Members.Remove(res);
                dbContext.SaveChanges();
                MessageBox.Show("刪除成功");
            }
            catch
            {
                email_txt.BorderBrush = Brushes.Red;
                MessageBox.Show("請填寫正確E-Mail");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)   //會員管理
        {
            //int a = 5;
            //int? b = 5;
            //b = null;
            var result = dbContext.Members.AsEnumerable().Select(x => new
            {
                E_mail = x.Member_Account,
                英文_姓 = x.Member_En_FirstName,
                英文_名 = x.Member_En_LastName,
                中文_姓 = x.Member_Ch_FirstName,
                中文_名 = x.Member_Ch_LastName,
                性別 = x.Member_Gender,
                生日 = x.Date_Of_Birth?.ToShortDateString(),  //DateTime"?"可用於nullable物件 空值，只顯示日期
                手機 = x.Member_Phone
            });
            datagrid1.ItemsSource = result.ToList();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            email_txt.Text = "jackywu547@gmail.com";
            cnFirst_txt.Text = "無";
            cnLast_txt.Text = "奇隆";
            phone_txt.Text = "0952120120";
        }
    }
}
