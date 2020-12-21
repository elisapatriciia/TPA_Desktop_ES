using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace TPA_ES.Model.TransactionModels
{
    class TransactionTypeDTO : INotifyPropertyChanged
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

        private string transactionTypeName;

        public string TransactionTypeName
        {
            get { return transactionTypeName; }
            set { transactionTypeName = value; }
        }

        private string transactionDescription;

        public string TransactionDescription
        {
            get { return transactionDescription; }
            set { transactionDescription = value; }
        }


    }
}
