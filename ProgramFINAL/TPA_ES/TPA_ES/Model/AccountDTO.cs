using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
namespace TPA_ES.Model
{
    class AccountDTO : INotifyPropertyChanged
    {

        public static string auth;

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

        private int typeId;

        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; OnPropertyChanged("TypeId"); }
        }

        private int customerId;

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; OnPropertyChanged("CustomerId"); }
        }

        private string accountNumber;

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; OnPropertyChanged("AccountNumber"); }
        }

        private string accountPin;

        public string AccountPin
        {
            get { return accountPin; }
            set { accountPin = value; }
        }


        private int balance;

        public int Balance
        {
            get { return balance; }
            set { balance = value; OnPropertyChanged("Balance"); }
        }
    }
}
