using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
namespace TPA_ES.Model.EmployeeModel
{
    class RequestTypeDTO : INotifyPropertyChanged
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

        private string requestTypeName;

        public string RequestTypeName
        {
            get { return requestTypeName; }
            set { requestTypeName = value; OnPropertyChanged("RequestTypeName"); }
        }

        private string requestDescription;

        public string RequestDescription
        {
            get { return requestDescription; }
            set { requestDescription = value; OnPropertyChanged("RequestDescription"); }
        }

    }
}
