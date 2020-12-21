using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel;
using TPA_ES.Model.EmployeeModel;
using TPA_ES.Command;
using System.Collections.ObjectModel;
using TPA_ES.Model;

namespace TPA_ES.ViewModel.EmployeeViewModels
{
    class EmployeeLeavingPermitViewModel : INotifyPropertyChanged
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
        //SAMPE VIEW MODEL, VIEW BLM BINDING, VALIDASI DI SERVICES BLM, 
        //EMPLOYEE HARUS ADA BARU BISA MINTA LEAVING PERMIT
        EmployeeLeavingPermitServices ObjEmployeeLeavingPermitServices;
        public EmployeeLeavingPermitViewModel()
        {
            ObjEmployeeLeavingPermitServices = new EmployeeLeavingPermitServices();
            LoadData();
            CurrentEmployee = new EmployeeDTO();
            CurrentEmployeeLP = new EmployeeLeavingPermitDTO();
            saveCommand = new RelayCommand(Save);
            CurrentEmployeeLP.LeavingDateStart = DateTime.Now.Date;
            CurrentEmployeeLP.LeavingDateEnd = CurrentEmployeeLP.LeavingDateStart;

        }

        #region CurrentEmployeeLP+CurrentEmployee+Message
        private EmployeeLeavingPermitDTO currentEmployeeLP;
        public EmployeeLeavingPermitDTO CurrentEmployeeLP
        {
            get { return currentEmployeeLP; }
            set { currentEmployeeLP = value; OnPropertyChanged("CurrentEmployeeLP"); }
        }

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
        #endregion
        #region DisplayOperation
        private ObservableCollection<EmployeeLeavingPermitDTO> employeeLPList;
        public ObservableCollection<EmployeeLeavingPermitDTO> EmployeeLPList
        {
            get { return employeeLPList; }
            set { employeeLPList = value; OnPropertyChanged("EmployeeLPList"); }
        }
        private void LoadData()
        {
            EmployeeLPList = new ObservableCollection<EmployeeLeavingPermitDTO>(ObjEmployeeLeavingPermitServices.GetAll());
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
                var IsSaved = ObjEmployeeLeavingPermitServices.Add(CurrentEmployeeLP, CurrentEmployeeLP.EmployeeID);
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
    }
}
