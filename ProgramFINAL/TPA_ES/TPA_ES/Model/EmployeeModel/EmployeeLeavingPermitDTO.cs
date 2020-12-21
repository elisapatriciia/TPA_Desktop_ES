using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
namespace TPA_ES.Model.EmployeeModel
{
    class EmployeeLeavingPermitDTO : INotifyPropertyChanged
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

        private int employeeID;

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; OnPropertyChanged("EmployeeID"); }
        }

        private string reason;

        public string Reason 
        {
            get { return reason; }
            set { reason = value; OnPropertyChanged("Reason"); }
        }

        private DateTime leavingDateStart;

        public DateTime LeavingDateStart
        {
            get { return leavingDateStart; }
            set { leavingDateStart = value; OnPropertyChanged("LeavingDateStart"); }
        }

        private DateTime leavingDateEnd;

        public DateTime LeavingDateEnd
        {
            get { return leavingDateEnd; }
            set { leavingDateEnd = value; OnPropertyChanged("LeavingDateEnd"); }
        }

    }
}
