using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Setiap buat ViewModel

using TPA_ES.Model.EmployeeModel;
using System.ComponentModel;
using TPA_ES.Model;
using TPA_ES.Command;
using System.Collections.ObjectModel;
namespace TPA_ES.ViewModel
{
    class EmployeeViewModel : INotifyPropertyChanged
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
        EmployeeServices ObjEmployeeServices;
        public EmployeeViewModel()
        {
            ObjEmployeeServices = new EmployeeServices();
            LoadData();
            CurrentEmployee = new EmployeeDTO();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
            addStatus();
            addPosition();

            //Violation
            LoadDataforViolation();
            searchEmployeeForViolationCommand = new RelayCommand(SearchEmployeeViolation);
            updateViolationCommand = new RelayCommand(UpdateViolationScore);

            requestFireEmployeeCommand = new RelayCommand(RequestFire);
            requestSalaryEmployeeCommand = new RelayCommand(RequestSalary);
            setSalaryEmployeeCommand = new RelayCommand(SetSalary);
            fireEmployeeCommand = new RelayCommand(FireEmployee);
            refuseRequestCommand = new RelayCommand(RefuseRequest);


            LoadDataforFIRE();
            LoadDataforSALARY();
        }
       

        //General
        #region CurrentEmployee+Message
        private EmployeeDTO currentEmployee;
        public EmployeeDTO CurrentEmployee
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

        private string positionID;

        public string PositionID
        {
            get { return positionID; }
            set { positionID = value; OnPropertyChanged("PositionID"); }
        }

        #endregion
        #region DisplayOperation
        private ObservableCollection<EmployeeDTO> employeeList;
        public ObservableCollection<EmployeeDTO> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; OnPropertyChanged("EmployeeList"); }
        }
        private void LoadData()
        {
            EmployeeList = new ObservableCollection<EmployeeDTO>(ObjEmployeeServices.GetAll());
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
                var IsSaved = ObjEmployeeServices.Add(CurrentEmployee, positionID);
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
                    CurrentEmployee.EmployeeName = ObjEmployee.EmployeeName;
                    CurrentEmployee.EmployeeStatus = ObjEmployee.EmployeeStatus;
                    CurrentEmployee.EmployeePositionID = (int)ObjEmployee.EmployeePositionID;
                    CurrentEmployee.EmployeeViolationScore = (int)ObjEmployee.EmployeeViolationScore;
                    CurrentEmployee.EmployeeSalay = (int)ObjEmployee.EmployeeSalay;
                }
                else
                {
                    Message = "Employee not found";
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
                var IsUpdated = ObjEmployeeServices.Update(CurrentEmployee, positionID);
                if (IsUpdated)
                {
                    Message = "Employee Updated";
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

        private void addStatus()
        {
            Status = new List<string>();
            Status.Add("Current Employee");
            Status.Add("Candidate");
        }

        private List<string> status;

        public List<string> Status
        {
            get { return status; }
            set { status = value; }
        }


        private void addPosition()
        {
            Position = new List<string>();
            Position.Add("Teller");
            Position.Add("Customer Service");
            Position.Add("Manager");
            Position.Add("Human Resource");
            Position.Add("Security and Maintenance");
            Position.Add("Finance");

        }

        private List<string> position;

        public List<string> Position
        {
            get { return position; }
            set { position = value; }
        }

        //Give Employee Violation Score
        #region DisplayOperationForViolationData
        private ObservableCollection<EmployeeDTO> employeeListforViolation;
        public ObservableCollection<EmployeeDTO> EmployeeListforViolation
        {
            get { return employeeListforViolation; }
            set { employeeListforViolation = value; OnPropertyChanged("EmployeeListforViolation"); }
        }
        private void LoadDataforViolation()
        {
            EmployeeListforViolation = new ObservableCollection<EmployeeDTO>(ObjEmployeeServices.GetViolationData());
        }
        #endregion
        #region SearchEmployeeForViolation
        private RelayCommand searchEmployeeForViolationCommand;
        public RelayCommand SearchEmployeeForViolation
        {
            get { return searchEmployeeForViolationCommand; }
        }
        public void SearchEmployeeViolation()
        {
            try
            {
                var ObjEmployee = ObjEmployeeServices.SearchEmployeeViolation(CurrentEmployee.Id);
                if (ObjEmployee != null)
                {
                    CurrentEmployee.EmployeeName = ObjEmployee.EmployeeName;
                    CurrentEmployee.EmployeeViolationScore = (int)ObjEmployee.EmployeeViolationScore;                  
                }
                else
                {
                    Message = "Employee not found";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region AddEmployeeViolationData
        private RelayCommand updateViolationCommand;
        public RelayCommand UpdateViolationCommand
        {
            get { return updateViolationCommand; }
        }

        //Update
        public void UpdateViolationScore()
        {
            try
            {
                var IsUpdated = ObjEmployeeServices.UpdateViolationScore(CurrentEmployee);
                if (IsUpdated)
                {
                    Message = "Employee Violation Updated";
                    LoadDataforViolation();
                }
                else
                {
                    Message = "Insert Employee Violation Failed";
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion


        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; OnPropertyChanged("ID"); }
        }

        private string reasons;

        public string Reasons
        {
            get { return reasons; }
            set { reasons = value; OnPropertyChanged("Reasons"); }
        }

        private int salaryRequest;

        public int SalaryRequest
        {
            get { return salaryRequest; }
            set { salaryRequest = value; OnPropertyChanged("SalaryRequest"); }
        }


        #region Request Pecat Employee
        private RelayCommand requestFireEmployeeCommand;
        public RelayCommand RequestFireEmployeeCommand
        {
            get { return requestFireEmployeeCommand; }
        }

        public void RequestFire()
        {
            try
            {
                var IsUpdated = ObjEmployeeServices.RequestFire(id, reasons);
                if (IsUpdated)
                {
                    Message = "Request Fire Save";
                    LoadDataforViolation();
                }
                else
                {
                    Message = "Request Fire Failed";
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region Request Pecat Employee
        private RelayCommand requestSalaryEmployeeCommand;
        public RelayCommand RequestSalaryEmployeeCommand
        {
            get { return requestSalaryEmployeeCommand; }
        }

        public void RequestSalary()
        {
            try
            {
                var IsUpdated = ObjEmployeeServices.RequestSalary(id, salaryRequest);
                if (IsUpdated)
                {
                    Message = "Request Salary Save";
                    LoadDataforViolation();
                }
                else
                {
                    Message = "Request Salary Failed";
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        //blm ditambahin kemana2
        #region Terima Request Salary
        private RelayCommand setSalaryEmployeeCommand;
        public RelayCommand SetSalaryEmployeeCommand
        {
            get { return setSalaryEmployeeCommand; }
        }

        public void SetSalary()
        {
            try
            {
                var IsUpdated = ObjEmployeeServices.UpdateSalary(id);
                if (IsUpdated)
                {
                    Message = "Salary Updated!";
                    LoadDataforViolation();
                }
                else
                {
                    Message = "Update Salary Failled";
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region Tolak Request apapun!
        private RelayCommand refuseRequestCommand;
        public RelayCommand RefuseRequestCommand
        {
            get { return refuseRequestCommand; }
        }

        public void RefuseRequest()
        {
            try
            {
                var IsUpdated = ObjEmployeeServices.DeleteRequest(id);
                if (IsUpdated)
                {
                    Message = "Request Dennied!";
                    LoadDataforViolation();
                }
                else
                {
                    Message = "Request Dennied Failled";
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region Terima Pecat Employee!
        private RelayCommand fireEmployeeCommand;
        public RelayCommand FireEmployeeCommand
        {
            get { return fireEmployeeCommand; }
        }

        public void FireEmployee()
        {
            try
            {
                var IsUpdated = ObjEmployeeServices.FireRequest(id);
                if (IsUpdated)
                {
                    Message = "Employee Fired!";
                    LoadDataforViolation();
                }
                else
                {
                    Message = "Employee Fire Failled";
                }

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region Tampilin Data PECAT!
        private ObservableCollection<RequestDTO> fireEmployeeList;
        public ObservableCollection<RequestDTO> FireEmployeeList
        {
            get { return fireEmployeeList; }
            set { fireEmployeeList = value; OnPropertyChanged("FireEmployeeList"); }
        }
        private void LoadDataforFIRE()
        {
            FireEmployeeList = new ObservableCollection<RequestDTO>(ObjEmployeeServices.GetRequestFireData());
        }
        #endregion

        #region Tampilin Data SALARY!
        private ObservableCollection<RequestDTO> salaryEmployeeList;
        public ObservableCollection<RequestDTO> SalaryEmployeeList
        {
            get { return salaryEmployeeList; }
            set { salaryEmployeeList = value; OnPropertyChanged("SalaryEmployeeList"); }
        }
        private void LoadDataforSALARY()
        {
            SalaryEmployeeList = new ObservableCollection<RequestDTO>(ObjEmployeeServices.GetRequestSalaryData());
        }
        #endregion
    }
}
