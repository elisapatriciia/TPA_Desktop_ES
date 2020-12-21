using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
namespace TPA_ES.Model.EmployeeModel
{
    class RequestDTO : INotifyPropertyChanged
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

        private int requestTypeID;

        public int RequestTypeID
        {
            get { return requestTypeID; }
            set { requestTypeID = value; OnPropertyChanged("RequestTypeID"); }
        }

        private int employeeID;

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; OnPropertyChanged("EmployeeID"); }
        }

        private string fireDescription;

        public string FireDescription
        {
            get { return fireDescription; }
            set { fireDescription = value; OnPropertyChanged("FireDescription"); }
        }

        private int salaryRequest;

        public int SalaryRequest
        {
            get { return salaryRequest; }
            set { salaryRequest = value; OnPropertyChanged("SalaryRequest"); }
        }

    }
}
