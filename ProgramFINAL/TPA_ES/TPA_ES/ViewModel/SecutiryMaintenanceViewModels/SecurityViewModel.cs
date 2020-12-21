using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using TPA_ES.Model.SecurityModel;
using TPA_ES.Command;
using System.Collections.ObjectModel;
using TPA_ES.Model.EmployeeModel;
namespace TPA_ES.ViewModel.SecutiryMaintenanceViewModels
{
    class SecurityViewModel : INotifyPropertyChanged
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

        SecurityServices securityServices;

        public SecurityViewModel()
        {
            securityServices = new SecurityServices();
            reportItemCommand = new RelayCommand(ReportItem);
            setScheduleCommand = new RelayCommand(SetSchedule);
            LoadItemData();
            //LoadScheduleData();
            LoadReportData();
            dateToRepair = DateTime.Now.Date;
        }

        #region variabel setter getter
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        private int employeeID;

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; OnPropertyChanged("EmployeeID"); }
        }

        private int itemCode;

        public int ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; OnPropertyChanged("ItemCode"); }
        }

        private string desc;

        public string Desc
        {
            get { return desc; }
            set { desc = value; OnPropertyChanged("Desc"); }
        }

        private int reportID;

        public int ReportID
        {
            get { return reportID; }
            set { reportID = value; OnPropertyChanged("ReportID"); }
        }

        private DateTime dateToRepair;

        public DateTime DateToRepair
        {
            get { return dateToRepair; }
            set { dateToRepair = value; OnPropertyChanged("DateToRepair"); }
        }

        private string itemStatus;

        public string ItemStatus
        {
            get { return itemStatus; }
            set { itemStatus = value; OnPropertyChanged("ItemStatus"); }
        }



        #endregion
        #region ReportBrokenItem
        private RelayCommand reportItemCommand;
        public RelayCommand ReportItemCommand
        {
            get { return reportItemCommand; }
        }
        public void ReportItem()
        {
            try
            {
                var IsSaved = securityServices.ReportBrokenItem(employeeID, itemCode, desc);

                if (IsSaved)
                    Message = "Item Reported Success!";
                else
                    Message = "Item Reported failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region DisplayItemList
        private ObservableCollection<ItemModel> itemList;
        public ObservableCollection<ItemModel> ItemList
        {
            get { return itemList; }
            set { itemList = value; OnPropertyChanged("ItemList"); }
        }
        private void LoadItemData()
        {
            ItemList = new ObservableCollection<ItemModel>(securityServices.GetAllItem());
        }
        #endregion

        #region View Schedule
        private ObservableCollection<ScheduleSMDTO> scheduleList;
        public ObservableCollection<ScheduleSMDTO> ScheduleList
        {
            get { return scheduleList; }
            set { scheduleList = value; OnPropertyChanged("ScheduleList"); }
        }
        //private void LoadScheduleData()
        //{
        //    ScheduleList = new ObservableCollection<ScheduleSMDTO>(securityServices.GetAllScheduleSM());
        //}
        #endregion

        #region SetSchedule
        private RelayCommand setScheduleCommand;
        public RelayCommand SetScheduleCommand
        {
            get { return setScheduleCommand; }
        }
        public void SetSchedule()
        {
            try
            {
                var IsSaved = securityServices.UpdateSchedule(reportID, dateToRepair, itemStatus);

                if (IsSaved)
                    Message = "Schedule Saved!";
                else
                    Message = "Schedule not saved";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region View Reported Item
        private ObservableCollection<ReportItemModel> reportList;
        public ObservableCollection<ReportItemModel> ReportList
        {
            get { return reportList; }
            set { reportList = value; OnPropertyChanged("ReportList"); }
        }
        private void LoadReportData()
        {
            ReportList = new ObservableCollection<ReportItemModel>(securityServices.GetAllReportedItem());
        }
        #endregion
    }
}
