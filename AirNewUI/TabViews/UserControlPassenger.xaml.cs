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
    /// UserControlPassenger.xaml 的互動邏輯
    /// </summary>
    public partial class UserControlPassenger : UserControl
    {
        public UserControlPassenger()
        {
            InitializeComponent();
        }
        //乘客
        public string Passanger
        {
            set
            {
                this.Passanger1.Content = value;
            }
            get
            {
                return this.Passanger1.Content.ToString();
            }
        }
        //護照編號
        public string PassPortID
        {
            set
            {
                this.PassPortid.Text = value;
            }
            get
            {
                return this.PassPortid.Text;
            }
        }
        //英文姓
        public string FirstName
        {
            set
            {
                this.Firstname.Text = value;
            }
            get
            {
                return this.Firstname.Text;
            }
        }
        //英文名
        public string LastName
        {
            set
            {
                this.Lastname.Text = value;
            }
            get
            {
                return this.Lastname.Text;
            }
        }
        //出生年月日
        public DateTime MyBirthDay
        {
            set
            {
                this.Mybirthday.SelectedDate = value;
            }
            get
            {
                return this.Mybirthday.SelectedDate.Value;
            }
        }
        //護照到期日
        public DateTime PassPortEndDate
        {
            set
            {
                this.Passportenddate.SelectedDate = value;
            }
            get
            {
                return this.Passportenddate.SelectedDate.Value;
            }
        }
    }
}
