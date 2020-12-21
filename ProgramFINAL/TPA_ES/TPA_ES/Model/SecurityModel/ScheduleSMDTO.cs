using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
namespace TPA_ES.Model.SecurityModel
{
    class ScheduleSMDTO : INotifyPropertyChanged
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

        private int reportID;

        public int ReportID
        {
            get { return reportID; }
            set { reportID = value; OnPropertyChanged("ReportID"); }
        }

        private int employeeID;

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; OnPropertyChanged("EmployeeID"); }
        }

        private DateTime dateToRepair;

        public DateTime DateToRepair
        {
            get { return dateToRepair; }
            set { dateToRepair = value; OnPropertyChanged("DateToRepair"); }
        }

        private string itemStatus;

        public string ItemStatus
        {
            get { return itemStatus; }
            set { itemStatus = value; OnPropertyChanged("ItemStatus"); }
        }
    }
}
