using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Setiap buat ViewModel
using System.ComponentModel;
using TPA_ES.Model;
using TPA_ES.Command;
using System.Collections.ObjectModel;

namespace TPA_ES.ViewModel
{
    class TellerViewModel : INotifyPropertyChanged
    {
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

        //Constructor
        CustomerServices ObjCustomerServices;
        public TellerViewModel()
        {
            ObjCustomerServices = new CustomerServices();
            LoadData();
            CurrentCustomer = new CustomerDTO();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }

        private CustomerDTO currentCustomer;
        public CustomerDTO CurrentCustomer
        {
            get { return currentCustomer; }
            set { currentCustomer = value; OnPropertyChanged("CurrentCustomer"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #region DisplayOperation
        private ObservableCollection<CustomerDTO> customersList;
        public ObservableCollection<CustomerDTO> CustomersList
        {
            get { return customersList; }
            set { customersList = value; OnPropertyChanged("CustomersList"); }
        }
        private void LoadData()
        {
            CustomersList = new ObservableCollection<CustomerDTO>(ObjCustomerServices.GetAll());
        }
        #endregion


        #region Save
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }
        public void Save()
        {
            try
            {
                var IsSaved = ObjCustomerServices.Add(CurrentCustomer);
                LoadData();
                if (IsSaved)
                    Message = "Customer saved";
                else
                    Message = "Save operation failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region Search
        //1. Bikin employeeServicesnya dulu
        //2. bikin ini
        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }

        //3. buat ini
        //4. tambahin ke contructor
        //5. Di button jgn lupa kasih Binding
        public void Search()
        {
            try
            {
                var ObjCustomer = ObjCustomerServices.Search(CurrentCustomer.Id);
                if (ObjCustomer != null)
                {
                    CurrentCustomer.CustomerName= ObjCustomer.CustomerName;
                    CurrentCustomer.CustomerDoB = ObjCustomer.CustomerDoB;
                }
                else
                {
                    Message = "Customer not found";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region Update
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }

        //Update
        public void Update()
        {
            try
            {
                var IsUpdated = ObjCustomerServices.Update(CurrentCustomer);
                if (IsUpdated)
                {
                    Message = "Customer Updated";
                    LoadData();
                }
                else
                {
                    Message = "Update Operation Failed";
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region Delete
        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }

        }
        public void Delete()
        {
            try
            {
                var IsDeleted = ObjCustomerServices.Delete(CurrentCustomer.Id);
                if (IsDeleted)
                {
                    Message = "Customer Deleted";
                    LoadData();
                }
                else
                {
                    Message = "Delete operation failed";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion
    }
}
