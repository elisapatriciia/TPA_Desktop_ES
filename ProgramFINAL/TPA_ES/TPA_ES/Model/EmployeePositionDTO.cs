using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace TPA_ES.Model
{
    class EmployeePositionDTO : INotifyPropertyChanged
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

        private string employeePositionName;

        public string EmployeePositionName
        {
            get { return employeePositionName; }
            set { employeePositionName = value; OnPropertyChanged("EmployeePositionName"); }
        }

        private int employeePositionSlot;

        public int EmployeePositionSlot
        {
            get { return employeePositionSlot; }
            set { employeePositionSlot = value; OnPropertyChanged("EmployeePositionSlot"); }
        }

    }
}
