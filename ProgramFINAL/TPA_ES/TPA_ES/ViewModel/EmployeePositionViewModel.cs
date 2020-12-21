using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using TPA_ES.Model;
using TPA_ES.Command;
using System.Collections.ObjectModel;
namespace TPA_ES.ViewModel
{
    class EmployeePositionViewModel : INotifyPropertyChanged
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

        EmployeePositionServices ObjEmployeePositionServices;

        public EmployeePositionViewModel()
        {
            ObjEmployeePositionServices = new EmployeePositionServices();
            LoadData();
        }

        #region DisplayOperation
        private ObservableCollection<EmployeePositionDTO> employeePositionList;
        public ObservableCollection<EmployeePositionDTO> EmployeePositionList
        {
            get { return employeePositionList; }
            set { employeePositionList = value; OnPropertyChanged("EmployeePositionList"); }
        }
        private void LoadData()
        {
            EmployeePositionList = new ObservableCollection<EmployeePositionDTO>(ObjEmployeePositionServices.GetAll());
        }
        #endregion
    }
}
