using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TPA_ES.Model.SecurityModel;
namespace TPA_ES.Model.SecurityModel
{
    class SecurityServices
    {
        KongBuEntities ObjContext;

        #region constructor
        public SecurityServices()
        {
            ObjContext = new KongBuEntities();
        }
        #endregion

        #region getAllItem
        public List<ItemModel> GetAllItem()
        {
            List<ItemModel> ObjItemList = new List<ItemModel>();
            try
            {
                var ObjQuery = from item in ObjContext.Items
                               select item;
                foreach (var item in ObjQuery)
                {
                    ObjItemList.Add(new ItemModel
                    {
                        Id = item.Id,
                        ItemName = item.ItemName
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjItemList;
        }

        #endregion

        #region Report Broken Item
        public bool ReportBrokenItem(int employeeID, int itemCode, string desc)
        {
            bool IsReported = false;
            try
            {
                var ObjEmployeeToFind = ObjContext.Employees.Find(employeeID);
                var ObjItemToFind = ObjContext.Items.Find(itemCode);

                if (employeeID == 0)
                    throw new ArgumentException("Insert Employee ID!");
                if (desc == "")throw new ArgumentException("Description of Item must be filled!");
                if (ObjEmployeeToFind == null)
                    throw new ArgumentException("Employee Not Found!");
                if(itemCode == 0)
                    throw new ArgumentException("Item code must be filled!");
                if (ObjItemToFind == null)
                    throw new ArgumentException("Item Not Found!");
               

                if (ObjEmployeeToFind != null)
                {
                    var ObjReportItem = new ReportItem();

                    ObjReportItem.EmployeeID = (int)ObjEmployeeToFind.Id;
                    ObjReportItem.EmployeePositionID = ObjEmployeeToFind.EmployeePositionID;
                    ObjReportItem.ItemCode = itemCode;
                    ObjReportItem.Description= desc;
                    //Tanggal report
                    ObjReportItem.ReportDate = DateTime.Now.Date;
                    ObjReportItem.RepairDate = DateTime.Now.Date;
                    ObjReportItem.ReportStatus = "";

                    ObjContext.ReportItems.Add(ObjReportItem);

                    var NoOfRowAffeccted = ObjContext.SaveChanges();
                    IsReported = NoOfRowAffeccted > 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return IsReported;
        }
        #endregion

        #region getAllReportedItem
        public List<ReportItemModel> GetAllReportedItem()
        {
            List<ReportItemModel> ObjReportedItemList = new List<ReportItemModel>();
            try
            {
                var ObjQuery = from reportedItem in ObjContext.ReportItems
                               select reportedItem;
                foreach (var reportedItem in ObjQuery)
                {
                    ObjReportedItemList.Add(new ReportItemModel
                    {
                        Id = reportedItem.Id,
                        ItemCode = (int)reportedItem.ItemCode,
                        Description = reportedItem.Description,
                        ReportDate = (DateTime)reportedItem.ReportDate,
                        RepairDate = (DateTime)reportedItem.RepairDate,
                        ReportStatus = (string)reportedItem.ReportStatus
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjReportedItemList;
        }

        #endregion

        //#region Set Schedule
        //public bool SetSchedule(int reportID, int employeeID, DateTime dateRepair, string status)
        //{
        //    bool IsSaved = false;
        //    try
        //    {
        //        var ObjEmployeeToFind = ObjContext.Employees.Find(employeeID);
        //        var ObjReportToFind = ObjContext.ReportItems.Find(reportID);
        //        //var objEmployeePosition = from employeePosition in ObjContext.EmployeePositions
        //        //                          select employeePosition;

        //        if (reportID == 0)
        //            throw new ArgumentException("Report ID must be filled!");
        //        if (ObjReportToFind == null)
        //            throw new ArgumentException("Report Data Not Found!");
        //        if (employeeID == 0)
        //            throw new ArgumentException("Insert Employee ID!");
        //        if (ObjEmployeeToFind == null)
        //            throw new ArgumentException("Employee Not Found!");   
        //        if(ObjEmployeeToFind.EmployeePositionID != 5)
        //        {
        //            throw new ArgumentException("Employee Must be from Security and Maintenance Team!");
        //        }
        //        if (dateRepair == null)
        //            throw new ArgumentException("Repair Date must be filled!");
        //        if(dateRepair <= ObjReportToFind.ReportDate) throw new ArgumentException("Repair Date must be more than report date");
        //        if (status == " ")
        //            throw new ArgumentException("Status of Item must be filled!");
        //        if (!(status == "Repaired" || status == "Pending"))
        //            throw new ArgumentException("Status of Item must be [Repaired | Pending]!");

        //        if (ObjReportToFind != null)
        //        {
        //            var ObjSchedule = new ScheduleSM();

        //            ObjSchedule.ReportID = ObjReportToFind.Id;
        //            ObjSchedule.EmployeeID = ObjEmployeeToFind.Id;
        //            ObjSchedule.DateToRepair = dateRepair;
        //            ObjSchedule.ItemStatus = status;
                    

        //            ObjContext.ScheduleSMs.Add(ObjSchedule);

        //            var NoOfRowAffeccted = ObjContext.SaveChanges();
        //            IsSaved = NoOfRowAffeccted > 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //    return IsSaved;
        //}
        //#endregion

        //#region ViewSchedule
        //public List<ScheduleSMDTO> GetAllScheduleSM()
        //{
        //    List<ScheduleSMDTO> ObjScheduleList = new List<ScheduleSMDTO>();
        //    try
        //    {
        //        var ObjQuery = from schedule in ObjContext.ScheduleSMs
        //                       select schedule;
        //        foreach (var schedule in ObjQuery)
        //        {
        //            ObjScheduleList.Add(new ScheduleSMDTO
        //            {
        //                Id = schedule.Id,
        //                ReportID = (int)schedule.ReportID,
        //                EmployeeID = (int)schedule.EmployeeID,
        //                DateToRepair = (DateTime)schedule.DateToRepair,
        //                ItemStatus = schedule.ItemStatus
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ObjScheduleList;
        //}
        //#endregion

        //Set Schedule ubah update reported Item aja
        #region UpdateSchedule
        public bool UpdateSchedule(int reportID, DateTime dateToRepair, string itemStatus)
        {
            bool IsUpdated = false;



            try
            {
                var ObjSchedule = ObjContext.ReportItems.Find(reportID);
                if (reportID == 0) throw new ArgumentException("Report ID must be filled!");
                if (ObjSchedule == null) throw new ArgumentException("Reported Item Not Found!");
                if (dateToRepair == null) throw new ArgumentException("Date to Repair must be Filled!");
                if (dateToRepair <= ObjSchedule.ReportDate) throw new ArgumentException("Repair Date must be more than report date");
                if (itemStatus == "")
                    throw new ArgumentException("Status of Item must be filled!");
                if (!(itemStatus == "Repaired" || itemStatus == "Pending"))
                    throw new ArgumentException("Status of Item must be [Repaired | Pending]!");
                ObjSchedule.RepairDate = dateToRepair;
                ObjSchedule.ReportStatus = itemStatus;
               

                var NoOfRowAffected = ObjContext.SaveChanges();
                IsUpdated = NoOfRowAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsUpdated;
        }
        #endregion
    }
}
