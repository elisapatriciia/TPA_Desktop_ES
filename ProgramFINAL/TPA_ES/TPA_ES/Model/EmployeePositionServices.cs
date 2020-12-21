using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA_ES.Model
{
    class EmployeePositionServices
    {
        KongBuEntities ObjContext;

        #region constructor
        public EmployeePositionServices()
        {
            ObjContext = new KongBuEntities();
        }
        #endregion

        //In General For Employee
        #region getAll
        public List<EmployeePositionDTO> GetAll()
        {
            List<EmployeePositionDTO> ObjEmployeePositionList = new List<EmployeePositionDTO>();
            try
            {
                var ObjQuery = from employeePosition in ObjContext.EmployeePositions
                               select employeePosition;
                foreach (var employeePosition in ObjQuery)
                {
                    ObjEmployeePositionList.Add(new EmployeePositionDTO
                    {
                        Id = employeePosition.Id,
                        EmployeePositionName = employeePosition.EmployeePositionName,
                        EmployeePositionSlot = (int)employeePosition.EmployeePositionSlot
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjEmployeePositionList;
        }

        #endregion
        #region AddEmployeePosition
        public bool Add(EmployeePositionDTO objNewEmployeePosition)
        {
            bool IsAdded = false;
            //contoh validasi
            //Gender must be between Female or Male
            //if (objNewCustomer.Gender != "Female" && objNewEmployee.Gender != "Male")
            //    throw new ArgumentException("Gender must be between Female or Male");

            try
            {
                var ObjEmployeePosition = new EmployeePosition();
                ObjEmployeePosition.Id = objNewEmployeePosition.Id;
                ObjEmployeePosition.EmployeePositionName = objNewEmployeePosition.EmployeePositionName;
                ObjEmployeePosition.EmployeePositionSlot = objNewEmployeePosition.EmployeePositionSlot;

                ObjContext.EmployeePositions.Add(ObjEmployeePosition);

                var NoOfRowAffeccted = ObjContext.SaveChanges();
                IsAdded = NoOfRowAffeccted > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsAdded;
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
                ObjEmployeePosition.EmployeePositionSlot =(int)objEmployeePositonUpdate.EmployeePositionSlot;                

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
                var ObjEmployeePositionToDelete = ObjContext.EmployeePositions.Find(id);
                ObjContext.EmployeePositions.Remove(ObjEmployeePositionToDelete);
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
        public EmployeePositionDTO SearchEmployeePosition(int id)
        {
            EmployeePositionDTO ObjEmployeePosition = null;

            try
            {
                var ObjEmployeePositionToFind = ObjContext.EmployeePositions.Find(id);
                if (ObjEmployeePositionToFind != null)
                {
                    ObjEmployeePosition = new EmployeePositionDTO()
                    {
                        Id = ObjEmployeePositionToFind.Id,
                        EmployeePositionName = ObjEmployeePositionToFind.EmployeePositionName,
                        EmployeePositionSlot = (int)ObjEmployeePositionToFind.EmployeePositionSlot,
                       

                    };

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjEmployeePosition;
        }
        #endregion

        public bool DecreasedPosition(int id)
        {
            bool IsUpdated = false;
            try
            {
                var ObjEmployeePositionToFind = ObjContext.EmployeePositions.Find(id);
                if(ObjEmployeePositionToFind != null)
                {
                    ObjEmployeePositionToFind.EmployeePositionSlot -= 1;

                    var NoOfRowAffected = ObjContext.SaveChanges();
                    IsUpdated = NoOfRowAffected > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return IsUpdated;
        }
        public bool IncreasedPosition(int id)
        {
            bool IsDelete= false;
            try
            {
                var ObjEmployeePositionToFind = ObjContext.EmployeePositions.Find(id);
                if (ObjEmployeePositionToFind != null)
                {
                    ObjEmployeePositionToFind.EmployeePositionSlot += 1;

                    var NoOfRowAffected = ObjContext.SaveChanges();
                    IsDelete = NoOfRowAffected > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return IsDelete;
        }
    }
}
