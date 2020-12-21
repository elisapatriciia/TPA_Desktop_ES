using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
namespace TPA_ES.Model
{
    class SiblingDTO : INotifyPropertyChanged
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

        private int customerId;

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; OnPropertyChanged("CustomerId"); }
        }

        private string siblingsName;

        public string SiblingsName
        {
            get { return siblingsName; }
            set { siblingsName = value; OnPropertyChanged("SiblingsName"); }
        }

    }
}
