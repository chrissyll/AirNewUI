using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirNewUI.Lab
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        public List<Student> Students { get; set; }
        public Student Stud;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 建立Command物件，可設定於Button Command屬性中
        /// </summary>
        private ICommand command1;
        public ICommand Command1
        {
            get { return this.command1 ?? (command1 = new RelayCommand { CanExecuteDelegate = x => true, ExecuteDelegate = x => this.PrefixNameWithAA() }); }
        }
        public StudentViewModel()
        {
            SampleData.Seed();
            Students = SampleData.Students;
            Stud = Students.First();

            //Command1 = new RelayCommand
            //{
            //    CanExecuteDelegate = x => true,
            //    ExecuteDelegate = x => this.PrefixNameWithAA()
            //};
        }

        public string Name
        {
            get { return Stud.Name; }

            set
            {
                if (Stud.Name != value)
                {
                    Stud.Name = value;
                    //當值有改變時，觸發event
                    RaisePropertyChanged("Name");
                }
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        int count = 0;
        public void PrefixNameWithAA()
        {
            ++count;
            Name = "AA" + count;
            command1.CanExecute(false);
        }
    }
}
