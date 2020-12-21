using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using TPA_ES.Model;
using TPA_ES.Command;
using TPA_ES.View.ATM_Machine;
using System.Collections.ObjectModel;
namespace TPA_ES.ViewModel.CustomerViewModels
{
    class CustomerViewModel : INotifyPropertyChanged
    {
        CustomerServices ObjCustomerServices;
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        public CustomerViewModel()
        {

            ObjCustomerServices = new CustomerServices();
            depositCommand = new RelayCommand(Deposit);
            withdrawCommand = new RelayCommand(Withdraw);
            transferCommand = new RelayCommand(Transfer);
            paymentCommand = new RelayCommand(Payments);

            //ATM
            accoutAuthCommand = new RelayCommand(AccountAuth);
            atmDepositCommand = new RelayCommand(ATMDeposit);
            atmTransferCommand = new RelayCommand(ATMTransfer);
            atmWithdrawCommand = new RelayCommand(ATMWithdraw);
            atmPaymentCommand = new RelayCommand(ATMPayments);
            atmTransferVACommand = new RelayCommand(ATMTransferVA);

        }

        #region variabel setter getter
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private string accountNumber;
        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; OnPropertyChanged("AccountNumber"); }
        }

        private string accountTo;

        public string AccountTo
        {
            get { return accountTo; }
            set { accountTo = value; OnPropertyChanged("AccountTo"); }
        }
        private int transferMoney;

        public int TransferMoney
        {
            get { return transferMoney; }
            set { transferMoney = value; }
        }

        private int paymentMoney;

        public int PaymentMoney
        {
            get { return paymentMoney; }
            set { paymentMoney = value; OnPropertyChanged("PaymentMoney"); }
        }

        private string paymentType;

        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; OnPropertyChanged("PaymentType"); }
        }

        #endregion

        #region DepositMoney
        private RelayCommand depositCommand;
        public RelayCommand DepositCommand
        {
            get { return depositCommand; }
        }

        private int depositMoney;
        public int DepositMoney
        {
            get { return depositMoney; }
            set { depositMoney = value; OnPropertyChanged("DepositMoney"); }
        }
        public void Deposit()
        {
            try
            {
                var IsSaved = ObjCustomerServices.DepositMoney(accountNumber, depositMoney);
                
                if (IsSaved)
                    Message = "Deposit Success!";
                else
                    Message = "Deposit failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region WithdrawMoney
        private RelayCommand withdrawCommand;
        public RelayCommand WithdrawCommand
        {
            get { return withdrawCommand; }
        }

      
        private int withdrawMoney;
        public int WithdrawMoney
        {
            get { return withdrawMoney; }
            set { withdrawMoney = value; OnPropertyChanged("WithdrawMoney"); }
        }
        public void Withdraw()
        {
            try
            {
                var IsSaved = ObjCustomerServices.WithDrawMoney(accountNumber, withdrawMoney);

                if (IsSaved)
                    Message = "Withdraw Success!";
                else
                    Message = "Withdraw failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region TransferMoney
        private RelayCommand transferCommand;
        public RelayCommand TransferCommand
        {
            get { return transferCommand;}
        }

        public void Transfer()
        {
            try
            {
                var IsSaved = ObjCustomerServices.TransferMoney(accountNumber, accountTo, transferMoney);

                if (IsSaved)
                    Message = "Transfer Success!";
                else
                    Message = "Transfer failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region Payment
        private RelayCommand paymentCommand;
        public RelayCommand PaymentCommand
        {
            get { return paymentCommand; }
        }

        public void Payments()
        {
            try
            {
                var IsSaved = ObjCustomerServices.Payments(accountNumber, accountTo,paymentType, paymentMoney);

                if (IsSaved)
                    Message = "Payment Success! tagihan lunas:D";
                else
                    Message = "Payment failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion


        //ATM
        #region CustomerAccountAuth
        private string accountPin;

        public string AccountPin
        {
            get { return accountPin; }
            set { accountPin = value; OnPropertyChanged("AccountPin"); }
        }


        private RelayCommand accoutAuthCommand;
        public RelayCommand AccoutAuthCommand
        {
            get { return accoutAuthCommand; }
        }

        public void AccountAuth()
        {
            try
            {
                var IsSaved = ObjCustomerServices.AccountAuth(accountNumber, accountPin);

                if (IsSaved)
                {
                    Message = "Authentication Success";
                    ATMView aTMView = new ATMView();
                    aTMView.Show();
                    Auth();

                }                                       
                else
                    Message = "Authentication failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }

            AccountDTO.auth = accountNumber;
        }

        public event EventHandler OnRequestClose;

        private void Auth()
        {
            OnRequestClose(this, new EventArgs());
        }
        #endregion

        #region DepositMoney
        private RelayCommand atmDepositCommand;
        public RelayCommand AtmDepositCommand
        {
            get { return atmDepositCommand; }
        }
        public void ATMDeposit()
        {
            try
            {
                var IsSaved = ObjCustomerServices.ATMDepositMoney(depositMoney);

                if (IsSaved)
                    Message = "Deposit Success!";
                else
                    Message = "Deposit failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region ATM WithdrawMoney
        private RelayCommand atmWithdrawCommand;
        public RelayCommand AtmWithdrawCommand
        {
            get { return atmWithdrawCommand; }
        }

        public void ATMWithdraw()
        {
            try
            {
                var IsSaved = ObjCustomerServices.ATMWithDrawMoney(withdrawMoney);

                if (IsSaved)
                    Message = "Withdraw Success!";
                else
                    Message = "Withdraw failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region ATM TransferMoney
        private RelayCommand atmTransferCommand;
        public RelayCommand AtmTransferCommand
        {
            get { return atmTransferCommand; }
        }

        public void ATMTransfer()
        {
            try
            {
                var IsSaved = ObjCustomerServices.ATMTransferMoney(accountTo, transferMoney);

                if (IsSaved)
                    Message = "Transfer Success!";
                else
                    Message = "Transfer failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region ATM Payment
        private RelayCommand atmPaymentCommand;
        public RelayCommand AtmPaymentCommand
        {
            get { return atmPaymentCommand; }
        }

        public void ATMPayments()
        {
            try
            {
                var IsSaved = ObjCustomerServices.ATMPayments(accountTo, paymentType, paymentMoney);

                if (IsSaved)
                    Message = "Payment Success! tagihan lunas:D";
                else
                    Message = "Payment failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region ATM Transfer VA
        private RelayCommand atmTransferVACommand;
        public RelayCommand AtmTransferVACommand
        {
            get { return atmTransferVACommand; }
        }

        public void ATMTransferVA()
        {
            try
            {
                var IsSaved = ObjCustomerServices.ATMTransferVA(accountTo, paymentMoney);

                if (IsSaved)
                    Message = "Transfer Success!";
                else
                    Message = "Transfer  failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion
    }
}
