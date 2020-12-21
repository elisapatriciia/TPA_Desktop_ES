using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using ES.Models;
using ES.Commands;
using System.Collections.ObjectModel;
namespace ES.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        //Constructor
        EmployeeServices ObjEmployeeServices;
        public EmployeeViewModel()
        {
            ObjEmployeeServices = new EmployeeServices();
            LoadData();
            CurrentEmployee = new Employee();
            //4.
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }

        #region DisplayOperation
        private ObservableCollection<Employee> employeesList;
        public ObservableCollection<Employee> EmployeesList
        {
            get { return employeesList; }
            set { employeesList = value; OnPropertyChanged("EmployeesList"); }
        }
        private void LoadData()
        {
            EmployeesList = new ObservableCollection<Employee>(ObjEmployeeServices.GetAll());
        }
        #endregion

        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; OnPropertyChanged("CurrentEmployee"); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

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
                var IsSaved = ObjEmployeeServices.Add(CurrentEmployee);
                LoadData();
                if (IsSaved)
                    Message = "Employee saved";
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
                var ObjEmployee = ObjEmployeeServices.Search(CurrentEmployee.Id);
                if (ObjEmployee != null)
                {
                    CurrentEmployee.Name = ObjEmployee.Name;
                    CurrentEmployee.Gender = ObjEmployee.Gender;
                }else
                {
                    Message = "Employee not found";
                }
            }
            catch(Exception ex)
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
                var IsUpdated = ObjEmployeeServices.Update(CurrentEmployee);
                if (IsUpdated)
                {
                    Message = "Employee Updated";
                    LoadData();
                }else
                {
                    Message = "Ipdate Operation Failed";
                }

            }
            catch(Exception ex)
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
                var IsDeleted = ObjEmployeeServices.Delete(CurrentEmployee.Id);
                if (IsDeleted)
                {
                    Message = "Employee Deleted";
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
