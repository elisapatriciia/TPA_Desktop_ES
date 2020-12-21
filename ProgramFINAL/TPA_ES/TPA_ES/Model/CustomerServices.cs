using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TPA_ES.Model;
using TPA_ES.Model.TransactionModels;
namespace TPA_ES.Model
{
    
    class CustomerServices
    {
        KongBuEntities ObjContext;

        #region constructor
        public CustomerServices()
        {
            ObjContext = new KongBuEntities();
        }
        #endregion

        public List<CustomerDTO> GetAll()
        {
            //return ObjEmployeeList;
            List<CustomerDTO> ObjCustomerList = new List<CustomerDTO>();
            try
            {
                var ObjQuery = from customer in ObjContext.Customers
                               select customer;
                foreach(var customer in ObjQuery)
                {
                    ObjCustomerList.Add(new CustomerDTO
                    {
                        Id = customer.Id,
                        CustomerName = customer.CustomerName,
                        CustomerDoB = customer.CustomerDoB
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

           

            return ObjCustomerList;
        }

 
        public bool Add(CustomerDTO objNewCustomer)
        {
            bool IsAdded = false;
            //contoh validasi
            //Gender must be between Female or Male
            //if (objNewCustomer.Gender != "Female" && objNewEmployee.Gender != "Male")
            //    throw new ArgumentException("Gender must be between Female or Male");

            try
            {
                var ObjCustomer = new Customer();
                ObjCustomer.Id = objNewCustomer.Id;
                ObjCustomer.CustomerName = objNewCustomer.CustomerName;
                ObjCustomer.CustomerDoB = objNewCustomer.CustomerDoB;

                ObjContext.Customers.Add(ObjCustomer);

                var NoOfRowAffeccted = ObjContext.SaveChanges();
                IsAdded = NoOfRowAffeccted > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsAdded;
        }

        public bool Update(CustomerDTO objCustomerUpdate)
        {
            bool IsUpdated = false;
          
            try
            {
                var ObjCustomer = ObjContext.Customers.Find(objCustomerUpdate.Id);
                ObjCustomer.CustomerName = objCustomerUpdate.CustomerName;
                ObjCustomer.CustomerDoB = objCustomerUpdate.CustomerDoB;
                var NoOfRowAffected = ObjContext.SaveChanges();
                IsUpdated = NoOfRowAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
            return IsUpdated;
        }

        //NANTI INI JADI CONTOH UTK YG LAIN KALO MAU ADA DELETE
        public bool Delete(int id)
        {
            bool IsDeleted = false;
           
            try
            {
                var ObjCustomerToDelete = ObjContext.Customers.Find(id);
                ObjContext.Customers.Remove(ObjCustomerToDelete);
                var NoOfRowAffected = ObjContext.SaveChanges();
                IsDeleted = NoOfRowAffected > 0; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsDeleted;
        }

        public CustomerDTO Search(int id)
        {
            CustomerDTO ObjCustomer = null;

            try
            {
                var ObjCustomerToFind = ObjContext.Customers.Find(id);
                if(ObjCustomerToFind != null)
                {
                    ObjCustomer = new CustomerDTO()
                    {
                        Id = ObjCustomerToFind.Id,
                        CustomerName = ObjCustomerToFind.CustomerName,
                        CustomerDoB = ObjCustomerToFind.CustomerDoB
                    };
                    
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
      
            return ObjCustomer;
        }

        //var acc = from ac in ObjContext.Accounts select ac;
        //Account temp = acc.FirstOrDefault();
        //temp.Customer.
        #region Deposit Money
        public bool DepositMoney(string accountNumber, int depositMoney)
        {
            bool IsDeposit = false;
            if (accountNumber == null) throw new ArgumentException("Insert Account Number!"); 
            try
            {
                var ObjAccountToFind = ObjContext.Accounts.Find(accountNumber);
                if (ObjAccountToFind == null)
                    throw new ArgumentException("Account Not Found!");
                if (ObjAccountToFind.TypeId != 1) throw new ArgumentException("Only Deposit Account that can be deposit");
                else if (depositMoney <= 0)
                    throw new ArgumentException("Input Deposit Money!");

                if (ObjAccountToFind != null)
                {
                    ObjAccountToFind.Balance += depositMoney;

                    //Add ke transaction
                    var ObjTransaction = new Transaction();              
                 
                    ObjTransaction.CustomerID = (int)ObjAccountToFind.CustomerId;
                    ObjTransaction.AccountID = ObjAccountToFind.AccountNumber;
                    ObjTransaction.TransactionTypeID = 1;
                    ObjTransaction.TransactionDate = DateTime.Now.Date;
                    ObjTransaction.Mutasi = depositMoney;

                    ObjContext.Transactions.Add(ObjTransaction);

                    var NoOfRowAffeccted = ObjContext.SaveChanges();
                    IsDeposit = NoOfRowAffeccted > 0;
                }
                //else
                //{
                //    throw new ArgumentException("Account Not Found!");
                //}
        }
            catch (Exception ex)
            {

                throw ex;
            }


            return IsDeposit;
        }
        #endregion
        #region Withdraw Money
        public bool WithDrawMoney(string accountNumber, int withdrawMoney)
        {
            bool IsWithdraw = false;
            if (accountNumber == null) throw new ArgumentException("Insert Account Number!");
            try
            {
                var ObjAccountToFind = ObjContext.Accounts.Find(accountNumber);
                if (ObjAccountToFind == null)
                    throw new ArgumentException("Account Not Found!");
                else if (withdrawMoney <= 0)
                    throw new ArgumentException("Input Money Amount!");
                else if (withdrawMoney > ObjAccountToFind.Balance)
                    throw new ArgumentException("Your Money Not Enough!");

                if (ObjAccountToFind != null)
                {
                    ObjAccountToFind.Balance -= withdrawMoney;

                    //Add ke transaction
                    var ObjTransaction = new Transaction();

                    ObjTransaction.CustomerID = (int)ObjAccountToFind.CustomerId;
                    ObjTransaction.AccountID = ObjAccountToFind.AccountNumber;
                    ObjTransaction.TransactionTypeID = 5;
                    ObjTransaction.TransactionDate = DateTime.Now.Date;
                    ObjTransaction.Mutasi = withdrawMoney;

                    ObjContext.Transactions.Add(ObjTransaction);

                    var NoOfRowAffeccted = ObjContext.SaveChanges();
                    IsWithdraw = NoOfRowAffeccted > 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return IsWithdraw;
        }
        #endregion

        #region TransferMoney
        public bool TransferMoney(string accountNumber, string accountTo,int transferMoney)
        {
            bool IsTransfer = false;
            if (accountNumber == null) throw new ArgumentException("Insert Account Number!");
            try
            {
                var ObjAccountFromToFind = ObjContext.Accounts.Find(accountNumber);
                var ObjAccountTo_ToFind = ObjContext.Accounts.Find(accountTo);
                if (ObjAccountFromToFind == null)
                    throw new ArgumentException("Account Not Found!");
                if (accountTo == null) throw new ArgumentException("Insert Account Destination Number!");
                if (ObjAccountTo_ToFind == null)
                    throw new ArgumentException("Account Destination Not Found!");
                else if (transferMoney < 10000)
                    throw new ArgumentException("Minimal amount Rp.10.000");
                else if (transferMoney > ObjAccountFromToFind.Balance)
                    throw new ArgumentException("You don't have enough money!");

                if (ObjAccountFromToFind != null)
                {
                    ObjAccountFromToFind.Balance -= transferMoney;
                    ObjAccountTo_ToFind.Balance += transferMoney;

                    //Add ke transaction
                    var ObjTransaction = new Transaction();

                    ObjTransaction.CustomerID = (int)ObjAccountFromToFind.CustomerId;
                    ObjTransaction.AccountID = ObjAccountFromToFind.AccountNumber;
                    ObjTransaction.AccountTo = accountTo;
                    ObjTransaction.TransactionTypeID = 2;
                    ObjTransaction.TransactionDate = DateTime.Now.Date;
                    ObjTransaction.Mutasi = transferMoney;

                    ObjContext.Transactions.Add(ObjTransaction);

                    var NoOfRowAffeccted = ObjContext.SaveChanges();
                    IsTransfer = NoOfRowAffeccted > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsTransfer;
        }
        #endregion

        #region Payments
        public bool Payments(string accountNumber, string vaNumber, string paymentType, int paymentMoney)
        {
            bool IsPayed = false;
            int paymentT = 0;

            if (accountNumber == null) throw new ArgumentException("Insert Account Number!");
            if (vaNumber == null) throw new ArgumentException("Insert Virtual Account Number!");
            try
            {
                var ObjAccountFromToFind = ObjContext.Accounts.Find(accountNumber);
                var ObjVA_ToFind = ObjContext.Accounts.Find(vaNumber);

                if (ObjAccountFromToFind == null)
                    throw new ArgumentException("Account Not Found!");
                else if (paymentType == null)
                    throw new ArgumentException("Payment Type must be filled [Electric Payment | Water Payment | Pulse Payment]");
                else if (ObjVA_ToFind == null)
                    throw new ArgumentException("Virtual Account Number Not Found!");
                else if (paymentType == null) throw new ArgumentException("Insert Payment Type!");
                else if (!(paymentType == "Electric Payment" || paymentType == "Water Payment" || paymentType == "Pulse Payment"))
                    throw new ArgumentException("Payment Type [Electric Payment | Water Payment | Pulse Payment]");
                else if (paymentMoney <= 0) throw new ArgumentException("Insert Money!");
                else if (paymentMoney != ObjVA_ToFind.Balance)
                    throw new ArgumentException("Your Payment Bills is " + ObjVA_ToFind.Balance);
                else if (paymentMoney > ObjAccountFromToFind.Balance)
                    throw new ArgumentException("Your Money Not Enough!");

                if (paymentType == "Electric Payment")
                    paymentT = 3;
                else if (paymentType == "Water Payment")
                    paymentT = 4;
                else if (paymentType == "Pulse Payment")
                    paymentT = 7;

                if (ObjAccountFromToFind != null)
                {
                    ObjAccountFromToFind.Balance -= paymentMoney;
                    ObjVA_ToFind.Balance -= paymentMoney;
                    //Add ke transaction
                    var ObjTransaction = new Transaction();

                    ObjTransaction.CustomerID = (int)ObjAccountFromToFind.CustomerId;
                    ObjTransaction.AccountID = ObjAccountFromToFind.AccountNumber;
                    ObjTransaction.AccountTo = vaNumber;
                    ObjTransaction.TransactionTypeID = paymentT;
                    ObjTransaction.TransactionDate = DateTime.Now.Date;
                    ObjTransaction.Mutasi = paymentMoney;

                    ObjContext.Transactions.Add(ObjTransaction);

                    var NoOfRowAffeccted = ObjContext.SaveChanges();
                    IsPayed = NoOfRowAffeccted > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsPayed;
        }
        #endregion


        //ATM
        #region CustomerAccountAuth
        public bool AccountAuth(string accountNumber, string accountPin)
        {
            bool IsAuth = false;
            if (accountNumber == null) throw new ArgumentException("Insert Account Number!");
            if (accountPin == null) throw new ArgumentException("Insert Account Pin!");
            try
            {
                var ObjAccountToFind = ObjContext.Accounts.Find(accountNumber);
                if (ObjAccountToFind == null)
                    throw new ArgumentException("Account Not Found!");
                else if (accountPin != ObjAccountToFind.AccountPin )
                    throw new ArgumentException("Invalid Pin!");
                IsAuth = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsAuth;
        }
        #endregion
        #region ATM Deposit Money
        public bool ATMDepositMoney( int depositMoney)
        {
            bool IsDeposit = false;
            //if (depositMoney == 0) throw new ArgumentException("Insert Deposit Money!");
            try
            {
                var ObjAccountToFind = ObjContext.Accounts.Find(AccountDTO.auth);
                if (ObjAccountToFind == null)
                    throw new ArgumentException("Account Not Found!");
                else if (depositMoney <= 0)
                    throw new ArgumentException("Input Deposit Money!");

                if (ObjAccountToFind != null)
                {
                    ObjAccountToFind.Balance += depositMoney;

                    //Add ke transaction
                    var ObjTransaction = new Transaction();

                    ObjTransaction.CustomerID = (int)ObjAccountToFind.CustomerId;
                    ObjTransaction.AccountID = ObjAccountToFind.AccountNumber;
                    ObjTransaction.TransactionTypeID = 1;
                    ObjTransaction.TransactionDate = DateTime.Now.Date;
                    ObjTransaction.Mutasi = depositMoney;

                    ObjContext.Transactions.Add(ObjTransaction);

                    var NoOfRowAffeccted = ObjContext.SaveChanges();
                    IsDeposit = NoOfRowAffeccted > 0;
                }
                //else
                //{
                //    throw new ArgumentException("Account Not Found!");
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return IsDeposit;
        }
        #endregion
        #region Withdraw Money
        public bool ATMWithDrawMoney(int withdrawMoney)
        {
            bool IsWithdraw = false;
            try
            {
                var ObjAccountToFind = ObjContext.Accounts.Find(AccountDTO.auth);
                if (ObjAccountToFind == null)
                    throw new ArgumentException("Account Not Found!");
                else if (withdrawMoney <= 0)
                    throw new ArgumentException("Input Money Amount!");
                else if (withdrawMoney > ObjAccountToFind.Balance)
                    throw new ArgumentException("Your Money Not Enough!");

                if (ObjAccountToFind != null)
                {
                    ObjAccountToFind.Balance -= withdrawMoney;

                    //Add ke transaction
                    var ObjTransaction = new Transaction();

                    ObjTransaction.CustomerID = (int)ObjAccountToFind.CustomerId;
                    ObjTransaction.AccountID = ObjAccountToFind.AccountNumber;
                    ObjTransaction.TransactionTypeID = 5;
                    ObjTransaction.TransactionDate = DateTime.Now.Date;
                    ObjTransaction.Mutasi = withdrawMoney;

                    ObjContext.Transactions.Add(ObjTransaction);

                    var NoOfRowAffeccted = ObjContext.SaveChanges();
                    IsWithdraw = NoOfRowAffeccted > 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return IsWithdraw;
        }
        #endregion

        #region ATM TransferMoney
        public bool ATMTransferMoney(string accountTo, int transferMoney)
        {
            bool IsTransfer = false;
            if (accountTo == null) throw new ArgumentException("Insert Account Destination!");
            try
            {
                var ObjAccountFromToFind = ObjContext.Accounts.Find(AccountDTO.auth);
                var ObjAccountTo_ToFind = ObjContext.Accounts.Find(accountTo);
                if (ObjAccountFromToFind == null)
                    throw new ArgumentException("Account Not Found!");
                if (ObjAccountTo_ToFind == null)
                    throw new ArgumentException("Account Destination Not Found!");
                if (transferMoney <= 0) throw new ArgumentException("Insert Money Amount!");
                else if (transferMoney < 10000)
                    throw new ArgumentException("Minimal amount Rp.10.000");
                else if (transferMoney > ObjAccountFromToFind.Balance)
                    throw new ArgumentException("Your Money Not Enough!");

                if (ObjAccountFromToFind != null)
                {
                    ObjAccountFromToFind.Balance -= transferMoney;
                    ObjAccountTo_ToFind.Balance += transferMoney;

                    //Add ke transaction
                    var ObjTransaction = new Transaction();

                    ObjTransaction.CustomerID = (int)ObjAccountFromToFind.CustomerId;
                    ObjTransaction.AccountID = ObjAccountFromToFind.AccountNumber;
                    ObjTransaction.AccountTo = accountTo;
                    ObjTransaction.TransactionTypeID = 2;
                    ObjTransaction.TransactionDate = DateTime.Now.Date;
                    ObjTransaction.Mutasi = transferMoney;

                    ObjContext.Transactions.Add(ObjTransaction);

                    var NoOfRowAffeccted = ObjContext.SaveChanges();
                    IsTransfer = NoOfRowAffeccted > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsTransfer;
        }
        #endregion

        #region ATM Payments
        public bool ATMPayments(string vaNumber, string paymentType, int paymentMoney)
        {
            bool IsPayed = false;
            int paymentT = 0;
            if (vaNumber == null) throw new ArgumentException("Insert Virtual Account Number!");
            if (paymentType == null) throw new ArgumentException("Insert Payment Type!");
            if (paymentMoney <= 0) throw new ArgumentException("Insert Money Amount!");
            try
            {
                var ObjAccountFromToFind = ObjContext.Accounts.Find(AccountDTO.auth);
                var ObjVA_ToFind = ObjContext.Accounts.Find(vaNumber);

                if (ObjAccountFromToFind == null)
                    throw new ArgumentException("Account Not Found!");
                else if (paymentType == null)
                    throw new ArgumentException("Payment Type must be filled [Electric Payment | Water Payment | Pulse Payment]");
                else if (ObjVA_ToFind == null)
                    throw new ArgumentException("Virtual Account Number Not Found!");
                else if (!(paymentType == "Electric Payment" || paymentType == "Water Payment" || paymentType == "Pulse Payment"))
                    throw new ArgumentException("Payment Type [Electric Payment | Water Payment | Pulse Payment]");

                else if (paymentMoney != ObjVA_ToFind.Balance)
                    throw new ArgumentException("Your Payment Bills is " + ObjVA_ToFind.Balance);
                else if (paymentMoney > ObjAccountFromToFind.Balance)
                    throw new ArgumentException("Your Money Not Enough!");

                if (paymentType == "Electric Payment")
                    paymentT = 3;
                else if (paymentType == "Water Payment")
                    paymentT = 4;
                else if (paymentType == "Pulse Payment")
                    paymentT = 7;

                if (ObjAccountFromToFind != null)
                {
                    ObjAccountFromToFind.Balance -= paymentMoney;
                    ObjVA_ToFind.Balance -= paymentMoney;
                    //Add ke transaction
                    var ObjTransaction = new Transaction();

                    ObjTransaction.CustomerID = (int)ObjAccountFromToFind.CustomerId;
                    ObjTransaction.AccountID = ObjAccountFromToFind.AccountNumber;
                    ObjTransaction.AccountTo = vaNumber;
                    ObjTransaction.TransactionTypeID = paymentT;
                    ObjTransaction.TransactionDate = DateTime.Now.Date;
                    ObjTransaction.Mutasi = paymentMoney;

                    ObjContext.Transactions.Add(ObjTransaction);

                    var NoOfRowAffeccted = ObjContext.SaveChanges();
                    IsPayed = NoOfRowAffeccted > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsPayed;
        }
        #endregion

        #region ATM Transfer VA
        public bool ATMTransferVA(string vaNumber, int paymentMoney)
        {
            bool IsTransfer = false;
            if (vaNumber == null) throw new ArgumentException("Insert Virtual Account Number!");
            if (paymentMoney <= 0) throw new ArgumentException("Insert Money Amount!");
            try
            {
                var ObjAccountFromToFind = ObjContext.Accounts.Find(AccountDTO.auth);
                var ObjVA_ToFind = ObjContext.Accounts.Find(vaNumber);

                if (ObjAccountFromToFind == null)
                    throw new ArgumentException("Account Not Found!");            
                else if (ObjVA_ToFind == null)
                    throw new ArgumentException("Virtual Account Number Not Found!");
                if (paymentMoney <= 0) throw new ArgumentException("Insert Money Amount!");
                else if (paymentMoney != ObjVA_ToFind.Balance)
                    throw new ArgumentException("Your Bills " + ObjVA_ToFind.Balance);
                else if (paymentMoney > ObjAccountFromToFind.Balance)
                    throw new ArgumentException("Your Money Not Enough!");

                if (ObjAccountFromToFind != null)
                {
                    ObjAccountFromToFind.Balance -= paymentMoney;
                    ObjVA_ToFind.Balance -= paymentMoney;
                    //Add ke transaction
                    var ObjTransaction = new Transaction();

                    ObjTransaction.CustomerID = (int)ObjAccountFromToFind.CustomerId;
                    ObjTransaction.AccountID = ObjAccountFromToFind.AccountNumber;
                    ObjTransaction.AccountTo = vaNumber;
                    ObjTransaction.TransactionDate = DateTime.Now.Date;
                    ObjTransaction.Mutasi = paymentMoney;

                    ObjContext.Transactions.Add(ObjTransaction);

                    var NoOfRowAffeccted = ObjContext.SaveChanges();
                    IsTransfer = NoOfRowAffeccted > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsTransfer;
        }
        #endregion

    }
}
