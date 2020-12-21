using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TPA_ES.Model.EmployeeModel;
namespace TPA_ES.Model
{
    class EmployeeServices
    {
        KongBuEntities ObjContext;

        #region constructor
        public EmployeeServices()
        {
            ObjContext = new KongBuEntities();
        }
        #endregion
        
        //In General For Employee
        #region getAll
        public List<EmployeeDTO> GetAll()
        {
            List<EmployeeDTO> ObjEmployeeList = new List<EmployeeDTO>();
            try
            {            
                var ObjQuery = from employe in ObjContext.Employees                               
                               select employe;
                foreach (var employee in ObjQuery)
                {
                    ObjEmployeeList.Add(new EmployeeDTO
                    {
                        Id = employee.Id,
                        EmployeeName = employee.EmployeeName,
                        EmployeeStatus = employee.EmployeeStatus,
                        EmployeePositionID = (int)employee.EmployeePositionID,
                        //EmployeeViolationScore = (int)employee.EmployeeViolationScore,
                        //EmployeeSalay = (int)employee.EmployeeSalay
                    });
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ObjEmployeeList;
        }

        #endregion
        #region AddEmployee
        public bool Add(EmployeeDTO objNewEmployee, string positionID)
        {
            bool IsAdded = false;
            //contoh validasi
            //Gender must be between Female or Male
            //if (objNewCustomer.Gender != "Female" && objNewEmployee.Gender != "Male")
            //    throw new ArgumentException("Gender must be between Female or Male");

            if (objNewEmployee.Id <= 0) throw new ArgumentException("Input Employee ID!");
            if (objNewEmployee.EmployeeName == null) throw new ArgumentException("Input Employee Name!");
            if (objNewEmployee.EmployeeStatus == null) throw new ArgumentException("Input Employee Status!");
            if (positionID == null) throw new ArgumentException("Choose Employee Position!");
            if (positionID == "Teller") objNewEmployee.EmployeePositionID = 1;
            if (positionID == "Customer Service") objNewEmployee.EmployeePositionID = 2;
            if (positionID == "Manager") objNewEmployee.EmployeePositionID = 3;
            if (positionID == "Human Resource") objNewEmployee.EmployeePositionID = 4;
            if (positionID == "Security and Maintenance") objNewEmployee.EmployeePositionID = 5;
            if (positionID == "Finance") objNewEmployee.EmployeePositionID = 6;
      

            //    Position.Add("Teller");
            //Position.Add("Customer Service");
            //Position.Add("Manager");
            //Position.Add("Human Resource");
            //Position.Add("Security and Maintenance");
            //Position.Add("Finance");

            try
            {
                var ObjEmployee = new Employee();
                ObjEmployee.Id = objNewEmployee.Id;
                ObjEmployee.EmployeeName = objNewEmployee.EmployeeName;
                ObjEmployee.EmployeeStatus = objNewEmployee.EmployeeStatus;
                ObjEmployee.EmployeePositionID = objNewEmployee.EmployeePositionID;
                ObjEmployee.EmployeeViolationScore = 0;
                ObjEmployee.EmployeeSalay = 0;

                ObjContext.Employees.Add(ObjEmployee);
                EmployeePositionServices ObjEmployeePositionServices = new EmployeePositionServices();
                ObjEmployeePositionServices.DecreasedPosition((int)ObjEmployee.EmployeePositionID);

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
        #region UpdateEmployee
        public bool Update(EmployeeDTO objEmployeeUpdate, string positionID)
        {
            bool IsUpdated = false;
            if (objEmployeeUpdate.Id <= 0) throw new ArgumentException("Input Employee ID!");
            if (objEmployeeUpdate.EmployeeName == null) throw new ArgumentException("Input Employee Name!");
            if (objEmployeeUpdate.EmployeeStatus == null) throw new ArgumentException("Input Employee Status!");
            if (positionID == "Teller") objEmployeeUpdate.EmployeePositionID = 1;
            if (positionID == "Customer Service") objEmployeeUpdate.EmployeePositionID = 2;
            if (positionID == "Manager") objEmployeeUpdate.EmployeePositionID = 3;
            if (positionID == "Human Resource") objEmployeeUpdate.EmployeePositionID = 4;
            if (positionID == "Security and Maintenance") objEmployeeUpdate.EmployeePositionID = 5;
            if (positionID == "Finance") objEmployeeUpdate.EmployeePositionID = 6;
            try
            {
                var ObjEmployee = ObjContext.Employees.Find(objEmployeeUpdate.Id);
                ObjEmployee.EmployeeName= objEmployeeUpdate.EmployeeName;
                ObjEmployee.EmployeeStatus = objEmployeeUpdate.EmployeeStatus;
                ObjEmployee.EmployeePositionID = objEmployeeUpdate.EmployeePositionID;
                //ObjEmployee.EmployeeViolationScore = objEmployeeUpdate.EmployeeViolationScore;
                //ObjEmployee.EmployeeLeavingPermitCOUNT = objEmployeeUpdate.EmployeeLeavingPermitCOUNT;
                //ObjEmployee.EmployeeSalay = objEmployeeUpdate.EmployeeSalay;

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
            if (id <= 0) throw new ArgumentException("Input Employee ID to Delete!");
            try
            {
                EmployeePositionServices employeePositionServices = new EmployeePositionServices();
                employeePositionServices.IncreasedPosition(id);
                var ObjEmployeeToDelete = ObjContext.Employees.Find(id);
                if (ObjEmployeeToDelete != null)
                {
                    ObjContext.Employees.Remove(ObjEmployeeToDelete);
                }
                else
                {
                    throw new ArgumentException("Employee Not Found!");
                }
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
        public EmployeeDTO Search(int id)
        {
            EmployeeDTO ObjEmployee = null;
            if (id <= 0) throw new ArgumentException("Input Employee ID to Search!");
            try
            {

                var ObjEmployeeToFind = ObjContext.Employees.Find(id);
                if (ObjEmployeeToFind != null)
                {
                    //if (positionID == "Teller") objNewEmployee.EmployeePositionID = 1;
                    //if (positionID == "Customer Service") objNewEmployee.EmployeePositionID = 2;
                    //if (positionID == "Manager") objNewEmployee.EmployeePositionID = 3;
                    //if (positionID == "Human Resource") objNewEmployee.EmployeePositionID = 4;
                    //if (positionID == "Security and Maintenance") objNewEmployee.EmployeePositionID = 5;
                    //if (positionID == "Finance") objNewEmployee.EmployeePositionID = 6;
                   
                    

                    ObjEmployee = new EmployeeDTO()
                    {
                        Id = ObjEmployeeToFind.Id,
                        EmployeeName = ObjEmployeeToFind.EmployeeName,
                        EmployeeStatus = ObjEmployeeToFind.EmployeeStatus,
                        EmployeePositionID = (int)ObjEmployeeToFind.EmployeePositionID,      
                    };
                    string PositionID = "";
                    if (ObjEmployeeToFind.EmployeePositionID == 1) PositionID = "Teller";
                    if (ObjEmployeeToFind.EmployeePositionID == 2) PositionID = "Customer Service";
                    if (ObjEmployeeToFind.EmployeePositionID == 3) PositionID = "Manager";
                    if (ObjEmployeeToFind.EmployeePositionID == 4) PositionID = "Human Resource";
                    if (ObjEmployeeToFind.EmployeePositionID == 5) PositionID = "Security and Maintenance";
                    if (ObjEmployeeToFind.EmployeePositionID == 6) PositionID = "Finance";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjEmployee;
        }
        #endregion

        //Atur Violation
        #region getViolationData
        public List<EmployeeDTO> GetViolationData()
        {
            List<EmployeeDTO> ObjEmployeeViolationData = new List<EmployeeDTO>();
            try
            {
                var ObjQuery = from employe in ObjContext.Employees
                               where employe.EmployeeStatus == "Current Employee"
                               select employe;
                foreach (var employee in ObjQuery)
                {
                    ObjEmployeeViolationData.Add(new EmployeeDTO
                    {
                        Id = employee.Id,
                        EmployeeName = employee.EmployeeName,
                        EmployeeViolationScore = (int)employee.EmployeeViolationScore
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjEmployeeViolationData;
        }

        #endregion
        #region UpdateEmployeeViolationScore
        public bool UpdateViolationScore(EmployeeDTO objEmployeeUpdate)
        {
            bool IsUpdated = false;
            if(objEmployeeUpdate.Id <= 0)
                throw new ArgumentException("Employee ID must be filled!");
            if (objEmployeeUpdate.EmployeeName == "") throw new ArgumentException("Insert Employee Name");
            if (objEmployeeUpdate.EmployeeViolationScore <= 0)
                throw new ArgumentException("Violation Score must be more than 0!");
            if (objEmployeeUpdate.EmployeeViolationScore > 100)
                throw new ArgumentException("Maximum of Violation Score in 100, you can request firing Employee");
            try
            {
                var ObjEmployee = ObjContext.Employees.Find(objEmployeeUpdate.Id);
                ObjEmployee.EmployeeName = objEmployeeUpdate.EmployeeName;
                ObjEmployee.EmployeeViolationScore = objEmployeeUpdate.EmployeeViolationScore;

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
        #region searchEmployeeViolationData
        public EmployeeDTO SearchEmployeeViolation(int id)
        {
            EmployeeDTO ObjEmployeeViolation = null;
            if (id <= 0) throw new ArgumentException("Insert Employee ID!");
            try
            {
                var ObjEmployeeToFind = ObjContext.Employees.Find(id);
               
                if (ObjEmployeeToFind != null)
                {
                    if (ObjEmployeeToFind.EmployeeStatus == "Current Employee")
                    {
                        ObjEmployeeViolation = new EmployeeDTO()
                        {
                            Id = ObjEmployeeToFind.Id,
                            EmployeeName = ObjEmployeeToFind.EmployeeName,
                            EmployeeViolationScore = (int)ObjEmployeeToFind.EmployeeViolationScore

                        };
                    }
                    else
                    {
                        throw new ArgumentException("There's no Current Employee");
                    }
                  

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjEmployeeViolation;
        }
        #endregion


        //Pecat dan Salary Request
        #region Request to Fire Employee
        public bool RequestFire(int employeeID, string reasons)
        {
            bool IsAdded = false;

            
            if (employeeID <= 0) throw new ArgumentException("Input Employee ID!");
            if (reasons == null) throw new ArgumentException("Input Reasons!");

            var ObjEmployee = ObjContext.Employees.Find(employeeID);
            if (ObjEmployee == null) throw new ArgumentException("Employee Not Found!");
            if (ObjEmployee.EmployeeViolationScore < 90) throw new ArgumentException("Employee Violation score must be more than 90!");

            try
            {
                var ObjRequestFire = new Request();
                ObjRequestFire.RequestTypeID = 1;
                ObjRequestFire.EmployeeID = employeeID;
                ObjRequestFire.FireDescription = reasons;
                ObjRequestFire.SalaryRequest = 0;
                ObjRequestFire.RequestStatus = "Pending";

                ObjContext.Requests.Add(ObjRequestFire);
                
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

        #region Request SALARY Employee
        public bool RequestSalary(int employeeID, int salaryRequest)
        {
            bool IsAdded = false;

            if (employeeID == 0) throw new ArgumentException("Input Employee ID!");
            if (salaryRequest == 0) throw new ArgumentException("Input Salary Request!");

            var ObjEmployee = ObjContext.Employees.Find(employeeID);
            if (ObjEmployee == null) throw new ArgumentException("Employee Not Found!");
            if (ObjEmployee.EmployeeStatus == "Candidate") throw new ArgumentException("Employee Must be a Current Employee!");
            if (ObjEmployee.EmployeeStatus == "Fired") throw new ArgumentException("Employee Already Fired");
            if (ObjEmployee.EmployeePositionID == 0) throw new ArgumentException("Employee Must be a Current Employee!");

            try
            {
                var ObjRequestSalary = new Request();
                ObjRequestSalary.RequestTypeID = 2;
                ObjRequestSalary.EmployeeID = employeeID;
                ObjRequestSalary.FireDescription = "";
                ObjRequestSalary.SalaryRequest = salaryRequest;
                ObjRequestSalary.RequestStatus = "Pending";

                ObjContext.Requests.Add(ObjRequestSalary);

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

        #region Update Employee Salary
        public bool UpdateSalary(int requestID)
        {
            bool IsAdded = false;

            if (requestID <= 0) throw new ArgumentException("Input Request ID!");          

            var ObjRequest = ObjContext.Requests.Find(requestID);
            if (ObjRequest.RequestTypeID != 2) throw new ArgumentException("Request must be Salary Request!");
            if (ObjRequest == null) throw new ArgumentException("Request Not Found!");

            if (ObjRequest.RequestStatus == "Accepted") throw new ArgumentException("Request already Accepted, Choose request that still Pending");
            if (ObjRequest.RequestStatus == "Not Accepted") throw new ArgumentException("Request already Not Accepted! Choose request that still Pending");
            try
            {
                ObjRequest.RequestStatus = "Accepted";

                var ObjEmployee = ObjContext.Employees.Find(ObjRequest.EmployeeID);
                ObjEmployee.EmployeeSalay = ObjRequest.SalaryRequest;

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

        #region Tolak Request
        //NANTI INI JADI CONTOH UTK YG LAIN KALO MAU ADA DELETE
        public bool DeleteRequest(int requestID)
        {

            bool IsDeleted = false;
            if (requestID <= 0) throw new ArgumentException("Input Request ID to Deny!");
            
            try
            {
                var ObjRequestToRefuse = ObjContext.Requests.Find(requestID);
                if (ObjRequestToRefuse.RequestStatus == "Accepted") throw new ArgumentException("Request already Accepted");
                if (ObjRequestToRefuse.RequestStatus == "Not Accepted") throw new ArgumentException("Request already Not Accepted!");
                if (ObjRequestToRefuse == null) throw new ArgumentException("Request Not Found!");

                if (ObjRequestToRefuse != null)
                {
                    ObjRequestToRefuse.RequestStatus = "Not Accepted";
                }
                else
                {
                    throw new ArgumentException("Request Not Found!");
                }
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

        #region Terima Request Pecat Employee
        //NANTI INI JADI CONTOH UTK YG LAIN KALO MAU ADA DELETE
        public bool FireRequest(int requestID)
        {
            bool IsFired = false;
            if (requestID <= 0) throw new ArgumentException("Input Employee ID to Fire!");
            try
            {
                var ObjReq = ObjContext.Requests.Find(requestID);
                if (ObjReq == null) throw new ArgumentException("Request Not Found!");
                if (ObjReq.RequestTypeID != 1) throw new ArgumentException("RequestType Must be Fire!");

                if (ObjReq.RequestStatus == "Accepted") throw new ArgumentException("Request already Accepted, Choose request that still Pending");
                if (ObjReq.RequestStatus == "Not Accepted") throw new ArgumentException("Request already Not Accepted! Choose request that still Pending");

                var ObjEmployeeToFire = ObjContext.Employees.Find(ObjReq.EmployeeID);

                if (ObjReq != null)
                {
                    ObjReq.RequestStatus = "Accepted";

                    ObjEmployeeToFire.EmployeeStatus = "Fired";
                    var NoOfRowAffeccted = ObjContext.SaveChanges();
                    IsFired = NoOfRowAffeccted > 0;
                }
                else
                {
                    throw new ArgumentException("Request Not Found!");
                }
                var NoOfRowAffected = ObjContext.SaveChanges();
                IsFired = NoOfRowAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return IsFired;
        }
        #endregion


        #region Get FIRE Request Data
        public List<RequestDTO> GetRequestFireData()
        {
            
            List<RequestDTO> ObjRequestData = new List<RequestDTO>();
            try
            {
                var ObjQuery = from request in ObjContext.Requests
                               where request.RequestTypeID == 1
                               select request;
                foreach (var request in ObjQuery)
                {
                    ObjRequestData.Add(new RequestDTO
                    {
                        Id = request.Id,
                        EmployeeID = (int)request.EmployeeID,
                        FireDescription = request.FireDescription,
                        RequestStatus = request.RequestStatus
                        
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjRequestData;
        }

        #endregion

        #region Get SALARY Request Data
        public List<RequestDTO> GetRequestSalaryData()
        {

            List<RequestDTO> ObjRequestData = new List<RequestDTO>();
            try
            {
                var ObjQuery = from request in ObjContext.Requests
                               where request.RequestTypeID == 2
                               select request;
                foreach (var request in ObjQuery)
                {
                    ObjRequestData.Add(new RequestDTO
                    {
                        Id = request.Id,
                        EmployeeID = (int)request.EmployeeID,
                        SalaryRequest = (int)request.SalaryRequest,
                        RequestStatus = request.RequestStatus
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjRequestData;
        }

        #endregion
    }
}
