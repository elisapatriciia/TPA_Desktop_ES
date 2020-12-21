using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA_ES.Model.EmployeeModel
{
    class EmployeeLeavingPermitServices
    {
        KongBuEntities ObjContext;

        public EmployeeLeavingPermitServices()
        {
            ObjContext = new KongBuEntities();
        }

        #region getAll
        public List<EmployeeLeavingPermitDTO> GetAll()
        {
            List<EmployeeLeavingPermitDTO> ObjEmployeeLeavingPermitList = new List<EmployeeLeavingPermitDTO>();
            try
            {
                var ObjQuery = from employeeLeavingPermit in ObjContext.EmployeeLeavingPermits
                               select employeeLeavingPermit;
                foreach (var employeeLeavingPermit in ObjQuery)
                {
                    ObjEmployeeLeavingPermitList.Add(new EmployeeLeavingPermitDTO
                    {
                        EmployeeID = employeeLeavingPermit.EmployeeID,
                        Reason= employeeLeavingPermit.Reason,
                        LeavingDateStart = employeeLeavingPermit.LeavingDateStart,
                        LeavingDateEnd = employeeLeavingPermit.LeavingDateEnd
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjEmployeeLeavingPermitList;
        }

        #endregion


        #region AddEmployeeLeavingPermit
        public bool Add(EmployeeLeavingPermitDTO objNewEmployeeLP, int id)
        {
            bool IsAdded = false;
            var ObjQuery = from employee in ObjContext.Employees
                           where employee.Id == id
                           select employee;
            Employee temp = ObjQuery.FirstOrDefault();

            if (objNewEmployeeLP.EmployeeID == 0) throw new ArgumentException("Insert Employee ID");
            if (temp == null) throw new ArgumentException("No Employee Found");
            if (objNewEmployeeLP.LeavingDateStart.Date == null) throw new ArgumentException("Insert Leaving Start Date!");
            if (objNewEmployeeLP.LeavingDateStart.Date <= DateTime.Now.Date)
            {
                throw new ArgumentException("Start Date must be more than today date");
            }
            if (objNewEmployeeLP.LeavingDateEnd.Date == null) throw new ArgumentException("Insert Leaving End Date!");
            else if (objNewEmployeeLP.LeavingDateEnd.Date <= objNewEmployeeLP.LeavingDateStart.Date)
            {
                throw new ArgumentException("End Date must be more than Start date");
            }
            else
            {
                try
                {
                    var ObjEmployeeLP = new EmployeeLeavingPermit();                   
                    ObjEmployeeLP.EmployeeID = objNewEmployeeLP.EmployeeID;
                    ObjEmployeeLP.Reason = objNewEmployeeLP.Reason;

                    ObjEmployeeLP.LeavingDateStart = objNewEmployeeLP.LeavingDateStart;
                    ObjEmployeeLP.LeavingDateEnd = objNewEmployeeLP.LeavingDateEnd;



                    ObjContext.EmployeeLeavingPermits.Add(ObjEmployeeLP);

                    var NoOfRowAffeccted = ObjContext.SaveChanges();
                    IsAdded = NoOfRowAffeccted > 0;

                }
                catch (Exception ex)
                {
                    return false;
                    throw ex;
                }
                return IsAdded;
            }
          
        }

        #endregion
        #region UpdateEmployeePosition
        public bool Update(EmployeePositionDTO objEmployeePositonUpdate)
        {
            bool IsUpdated = false;


            try
            {
                var ObjEmployeePosition = ObjContext.EmployeePositions.Find(objEmployeePositonUpdate.Id);
                ObjEmployeePosition.EmployeePositionName = objEmployeePositonUpdate.EmployeePositionName;
                ObjEmployeePosition.EmployeePositionSlot = (int)objEmployeePositonUpdate.EmployeePositionSlot;

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
        #region Delete
        //NANTI INI JADI CONTOH UTK YG LAIN KALO MAU ADA DELETE
        public bool Delete(int id)
        {
            bool IsDeleted = false;

            try
            {
                var ObjEmployeeLPToDelete = ObjContext.EmployeeLeavingPermits.Find(id);
                ObjContext.EmployeeLeavingPermits.Remove(ObjEmployeeLPToDelete);
                var NoOfRowAffected = ObjContext.SaveChanges();
                IsDeleted = NoOfRowAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsDeleted;
        }
        #endregion
        #region Search
        public EmployeeLeavingPermitDTO SearchEmployeeLeavingPermit(int id)
        {
            EmployeeLeavingPermitDTO ObjEmployeeLP = null;

            try
            {
                var ObjEmployeeLPToFind = ObjContext.EmployeeLeavingPermits.Find(id);
                if (ObjEmployeeLPToFind != null)
                {
                    ObjEmployeeLP = new EmployeeLeavingPermitDTO()
                    {
                        Id = ObjEmployeeLPToFind.Id,
                        EmployeeID = ObjEmployeeLPToFind.EmployeeID,
                        Reason= ObjEmployeeLPToFind.Reason,
                        LeavingDateStart = ObjEmployeeLPToFind.LeavingDateStart,
                        LeavingDateEnd = ObjEmployeeLPToFind.LeavingDateEnd
                    };

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjEmployeeLP;
        }
        #endregion
    }
}
