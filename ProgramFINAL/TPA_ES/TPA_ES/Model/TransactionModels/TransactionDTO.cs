using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace TPA_ES.Model.TransactionModels
{
    class TransactionDTO : INotifyPropertyChanged
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

        private int customerID;

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; OnPropertyChanged("CustomerID"); }
        }

        private string accountID;

        public string AccountID
        {
            get { return accountID; }
            set { accountID = value; OnPropertyChanged("AccountID"); }
        }

        private string accountTo;

        public string AccountTo
        {
            get { return accountTo; }
            set { accountTo = value; OnPropertyChanged("AccountTo"); }
        }


        private int transactionTypeID;

        public int TransactionTypeID
        {
            get { return transactionTypeID; }
            set { transactionTypeID = value; OnPropertyChanged("transactionTypeID"); }
        }

        private DateTime transactionDate;

        public DateTime TransactionDate
        {
            get { return transactionDate; }
            set { transactionDate = value; OnPropertyChanged("TransactionDate"); }
        }

        private int mutasi;

        public int Mutasi
        {
            get { return mutasi; }
            set { mutasi = value; }
        }



    }
}
