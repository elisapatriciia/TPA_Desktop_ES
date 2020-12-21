using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
namespace TPA_ES.Model 
{
	class EmployeeDTO : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

      
        private string employeeName;

        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; OnPropertyChanged("EmployeeName"); }
        }

        private string employeeStatus;

        public string EmployeeStatus
        {
            get { return employeeStatus; }
            set { employeeStatus = value; OnPropertyChanged("EmployeeStatus"); }
        }

        private int employeePositionID;

        public int EmployeePositionID
        {
            get { return employeePositionID; }
            set { employeePositionID = value; OnPropertyChanged("EmployeePositionID"); }
        }

        private int employeeViolationScore;

        public int EmployeeViolationScore
        {
            get { return employeeViolationScore; }
            set { employeeViolationScore = value; OnPropertyChanged("EmployeeViolationScore"); }
        }

        private int employeeSalay;

        public int EmployeeSalay
        {
            get { return employeeSalay; }
            set { employeeSalay = value; OnPropertyChanged("EmployeeSalay"); }
        }
    }
}
