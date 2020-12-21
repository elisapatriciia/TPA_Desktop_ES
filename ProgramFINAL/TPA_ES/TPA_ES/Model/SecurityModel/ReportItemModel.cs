using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
namespace TPA_ES.Model.SecurityModel
{
    class ReportItemModel : INotifyPropertyChanged
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

        private int emplpoyeeID;

        public int EmplpoyeeID
        {
            get { return emplpoyeeID; }
            set { emplpoyeeID = value; OnPropertyChanged("EmplpoyeeID"); }
        }

        private int emplpoyeePositionID;

        public int EmplpoyeePositionID
        {
            get { return emplpoyeePositionID; }
            set { emplpoyeePositionID = value; OnPropertyChanged("EmplpoyeePositionID"); }
        }

        private int itemCode;

        public int ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; OnPropertyChanged("ItemCode"); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        private DateTime reportDate;

        public DateTime ReportDate
        {
            get { return reportDate; }
            set { reportDate = value; OnPropertyChanged("ReportDate"); }
        }

        private DateTime repairDate;

        public DateTime RepairDate
        {
            get { return repairDate; }
            set { repairDate = value; OnPropertyChanged("RepairDate"); }
        }

        private string reportStatus;

        public string ReportStatus
        {
            get { return reportStatus; }
            set { reportStatus = value; OnPropertyChanged("ReportStatus"); }
        }
    }
}
