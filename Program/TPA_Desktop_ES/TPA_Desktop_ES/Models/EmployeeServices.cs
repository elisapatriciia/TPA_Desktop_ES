using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA_Desktop_ES.Models
{
    public class EmployeeServices
    {
        private static List<Employee> ObjEmployeeList;

        public EmployeeServices()
        {
            ObjEmployeeList = new List<Employee>()
            {
                new Employee { Id = 001, Name = "Elisa Patricia", Gender = "Female" }
            };
        }

        public List<Employee> GetAll()
        {
            return ObjEmployeeList;
        }

        public bool Add(Employee objNewEmployee)
        {
            //contoh validasi
            //Gender must be between Female or Male
            if (objNewEmployee.Gender != "Female" || objNewEmployee.Gender != "Male")
                throw new ArgumentException("Gender must be between Female or Male");

            ObjEmployeeList.Add(objNewEmployee);
            return true;
        }

        public bool Update(Employee objEmployeeUpdate)
        {
            bool IsUpdated = false;
            for(int index = 0; index < ObjEmployeeList.Count; index++)
            {
                if(ObjEmployeeList[index].Id == objEmployeeUpdate.Id)
                {
                    ObjEmployeeList[index].Name = objEmployeeUpdate.Name;
                    ObjEmployeeList[index].Gender = objEmployeeUpdate.Gender;
                    IsUpdated = true;
                    break;
                }
            }
            return IsUpdated;
        }

        public bool Delete(int id)
        {
            bool IsDeleted = false;
            for(int i = 0; i < ObjEmployeeList.Count; i++)
            {
                if(ObjEmployeeList[i].Id == id)
                {
                    ObjEmployeeList.RemoveAt(i);
                    IsDeleted = true;
                    break;
                }
            }
            return IsDeleted;
        }

        public Employee Search(int id)
        {
            return ObjEmployeeList.FirstOrDefault(e => e.Id == id);
        }
    }
}
