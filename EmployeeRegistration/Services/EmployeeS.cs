using EmployeeRegistration.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeRegistration.Services
{
    public class EmployeeS : ConnectionClass
    {
        public List<Employee> EmployeeDetails()
        {
            List<Employee> employees = new List<Employee>();
            //SqlConnection sqlConnection = new SqlConnection(connectionString);
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = sqlConnection;
            connection();
            sqlCommand.CommandText = "select * from Employee";
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(dataReader[0]);
                employee.FirstName = Convert.ToString(dataReader[1]);
                employee.LastName = Convert.ToString(dataReader[2]);
                employee.PrimaryEmail = Convert.ToString(dataReader[3]);
                employee.PhoneNumber = Convert.ToString(dataReader[4]);
                employee.DateOfBirth = Convert.ToString(dataReader[5]);
                employee.ReportsTo = (dataReader["ReportsTo"]) == DBNull.Value ? 0 : Convert.ToInt32(dataReader["ReportsTo"]);
                employees.Add(employee);
            }
            return employees;
           // sqlConnection.Close();
        }
        public List<Employee> EmployeeDetailsById(int Id)
        {
            List<Employee> employees = new List<Employee>();
            connection();
            sqlCommand.CommandText = "select * from Employee where Id=@id";
            sqlCommand.Parameters.AddWithValue("@id", Id);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(dataReader[0]);
                employee.FirstName = Convert.ToString(dataReader[1]);
                employee.LastName = Convert.ToString(dataReader[2]);
                employee.PrimaryEmail = Convert.ToString(dataReader[3]);
                employee.PhoneNumber = Convert.ToString(dataReader[4]);
                employee.DateOfBirth = Convert.ToString(dataReader[5]);
                employee.ReportsTo = (dataReader["ReportsTo"]) == DBNull.Value ? 0 : Convert.ToInt32(dataReader["ReportsTo"]);


                employees.Add(employee);
            }
            return employees;
            //sqlConnection.Close();
        }
        public void CreateEmployee(Emp employee)
        {
            connection();
            string procedure = "AddEmployee";
            sqlCommand.CommandText = procedure;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
      // sqlCommand.Parameters.AddWithValue("@Id", employee.Id);
            sqlCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", employee.LastName);
            sqlCommand.Parameters.AddWithValue("@PrimaryEmail", employee.PrimaryEmail);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@ReportsTo", employee.ReportsTo);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
        public void EditEmployee(Employee employee)
        {
            connection();
            string procedure = "EditEmployee";
            sqlCommand.CommandText = procedure;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
          sqlCommand.Parameters.AddWithValue("@Id", employee.Id);
            sqlCommand.Parameters.AddWithValue("@FirstName", employee.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", employee.LastName);
            sqlCommand.Parameters.AddWithValue("@PrimaryEmail", employee.PrimaryEmail);
            sqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            sqlCommand.Parameters.AddWithValue("@ReportsTo", employee.ReportsTo);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void DeleteEmployee(int Id)
        {
            connection();
            string procedure = "DeleteEmployee";
            sqlCommand.CommandText = procedure;
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id",Id);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

        }
        public List<Employee> DirectReportees(int Id)
        {
            List<Employee> employees = new List<Employee>();
            connection();
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = "select * from Employee where ReportsTo=@id";
            sqlCommand.Parameters.AddWithValue("@id", Id);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(dataReader["ID"]);
                employee.FirstName = Convert.ToString(dataReader["FirstName"]);
                employee.LastName = Convert.ToString(dataReader["LastName"]);
                employee.PhoneNumber= Convert.ToString(dataReader["PhoneNumber"]);
                employee.PrimaryEmail = Convert.ToString(dataReader["PrimaryEmail"]);
                employee.DateOfBirth = Convert.ToString(dataReader["DateOfBirth"]);
                employee.ReportsTo = (dataReader["ReportsTo"]) == DBNull.Value ? 0 : Convert.ToInt32(dataReader["ReportsTo"]);
                 employees.Add(employee);
            }

            return employees;
        }
        public List<Employee> InDirectReportees(int Id)
        {
            List<Employee> employees = new List<Employee>();
            connection();
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = "select * from Employee where ReportsTo in (select ID from Employee where ReportsTo = @id)";
            sqlCommand.Parameters.AddWithValue("@id", Id);
            sqlConnection.Open();
            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(dataReader["ID"]);
                employee.FirstName = Convert.ToString(dataReader["FirstName"]);
                employee.LastName = Convert.ToString(dataReader["LastName"]);
                employee.PhoneNumber = Convert.ToString(dataReader["PhoneNumber"]);
                employee.PrimaryEmail = Convert.ToString(dataReader["PrimaryEmail"]);
                employee.DateOfBirth = Convert.ToString(dataReader["DateOfBirth"]);
                employee.ReportsTo = (dataReader["ReportsTo"]) == DBNull.Value ? 0 : Convert.ToInt32(dataReader["ReportsTo"]);
                employees.Add(employee);
            }

            return employees;
        }
    }
    }