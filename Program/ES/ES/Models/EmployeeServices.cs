using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

using System.Data;
using System.Data.SqlClient;
namespace ES.Models
{
    public class EmployeeServices
    {
        SqlConnection ObjSqlConnection;
        SqlCommand ObjSqlCommand;
        //private static List<Employee> ObjEmployeeList;

        public EmployeeServices()
        {
            //ObjEmployeeList = new List<Employee>()
            //{
            //    new Employee { Id = 1, Name = "Elisa Patricia", Gender = "Female" }
            //};

            ObjSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["EMSConnection"].ConnectionString);
            ObjSqlCommand = new SqlCommand();
            ObjSqlCommand.Connection = ObjSqlConnection;
            ObjSqlCommand.CommandType = CommandType.StoredProcedure;

        }

        public List<Employee> GetAll()
        {
            //return ObjEmployeeList;
            List<Employee> ObjEmployeeList = new List<Employee>();
            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "upd_SelectAllEmployees";

                ObjSqlConnection.Open();
                var ObjSqlDataReader = ObjSqlCommand.ExecuteReader();
                if (ObjSqlDataReader.HasRows)
                {
                    Employee ObjEmployee = null;
                    while (ObjSqlDataReader.Read())
                    {
                        ObjEmployee = new Employee();
                        ObjEmployee.Id = ObjSqlDataReader.GetInt32(0);
                        ObjEmployee.Name = ObjSqlDataReader.GetString(1);
                        ObjEmployee.Gender = ObjSqlDataReader.GetString(1);

                        ObjEmployeeList.Add(ObjEmployee);
                    }
                }
                ObjSqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }
            return ObjEmployeeList;
        }

        public bool Add(Employee objNewEmployee)
        {
            bool IsAdded = false;
            //contoh validasi
            //Gender must be between Female or Male
            if (objNewEmployee.Gender != "Female" && objNewEmployee.Gender != "Male")
                throw new ArgumentException("Gender must be between Female or Male");

            //ObjEmployeeList.Add(objNewEmployee);
            //upd_InsertEmployee
            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "upd_InsertEmployee";
                ObjSqlCommand.Parameters.AddWithValue("@Id", objNewEmployee.Id);
                ObjSqlCommand.Parameters.AddWithValue("@Name", objNewEmployee.Name);
                ObjSqlCommand.Parameters.AddWithValue("@Gender", objNewEmployee.Gender);

                ObjSqlConnection.Open();
                int NoOfRowsAffected = ObjSqlCommand.ExecuteNonQuery();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }

            return IsAdded;
        }

        public bool Update(Employee objEmployeeUpdate)
        {
            bool IsUpdated = false;
            //for (int index = 0; index < ObjEmployeeList.Count; index++)
            //{
            //    if (ObjEmployeeList[index].Id == objEmployeeUpdate.Id)
            //    {
            //        ObjEmployeeList[index].Name = objEmployeeUpdate.Name;
            //        ObjEmployeeList[index].Gender = objEmployeeUpdate.Gender;
            //        IsUpdated = true;
            //        break;
            //    }
            //}

            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "upd_UpdateEmployee";
                ObjSqlCommand.Parameters.AddWithValue("@Id", objEmployeeUpdate.Id);
                ObjSqlCommand.Parameters.AddWithValue("@Name", objEmployeeUpdate.Name);
                ObjSqlCommand.Parameters.AddWithValue("@Gender", objEmployeeUpdate.Gender);

                ObjSqlConnection.Open();
                int NoOfRowsAffected = ObjSqlCommand.ExecuteNonQuery();
                IsUpdated = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }
            return IsUpdated;
        }

        public bool Delete(int id)
        {
            bool IsDeleted = false;
            //for (int i = 0; i < ObjEmployeeList.Count; i++)
            //{
            //    if (ObjEmployeeList[i].Id == id)
            //    {
            //        ObjEmployeeList.RemoveAt(i);
            //        IsDeleted = true;
            //        break;
            //    }
            //}upd_DeleteEmployee
            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "upd_DeleteEmployee";
                ObjSqlCommand.Parameters.AddWithValue("@Id", id);

                ObjSqlConnection.Open();
                int NoOfRowsAffected = ObjSqlCommand.ExecuteNonQuery();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }
            return IsDeleted;
        }

        public Employee Search(int id)
        {
            //return ObjEmployeeList.FirstOrDefault(e => e.Id == id);
            Employee ObjEmployee = null;

            try
            {
                ObjSqlCommand.Parameters.Clear();
                ObjSqlCommand.CommandText = "upd_SelectEmployeeById";
                ObjSqlCommand.Parameters.AddWithValue("@Id", id);

                ObjSqlConnection.Open();
                var ObjSqlDataReader = ObjSqlCommand.ExecuteReader();
                if (ObjSqlDataReader.HasRows)
                {
                    ObjSqlDataReader.Read();
                    ObjEmployee = new Employee();
                    ObjEmployee.Id = ObjSqlDataReader.GetInt32(0);
                    ObjEmployee.Name = ObjSqlDataReader.GetString(1);
                    ObjEmployee.Gender = ObjSqlDataReader.GetString(1);

                }
                ObjSqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ObjSqlConnection.Close();
            }
            return ObjEmployee;
        }
    }
}
