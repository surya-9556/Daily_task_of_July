using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingProjectEmployee.Models;
using System.Data.SqlClient;
using System.Data;

namespace TestingProjectEmployee.EmployeeService
{
    public class SoftEmployee : IEmployee<Employee>
    {
        SalaryEntities SE;

        public SoftEmployee()
        {
            SE = new SalaryEntities();
        }

        public int Add(Employee t)
        {
            try
            {
                string con = "server=SURYA-CHANDRA;Integrated security=true;database=SalaryPrediction;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    string Choice = "Insert";
                    using (SqlCommand cmd = new SqlCommand("Employee.Crud", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeName", SqlDbType.NVarChar).Value = t.EmployeeName;
                        cmd.Parameters.AddWithValue("@BirthDate", SqlDbType.Int).Value = t.BirthDate;
                        cmd.Parameters.AddWithValue("@HireDate", SqlDbType.Money).Value = t.HireDate;
                        cmd.Parameters.AddWithValue("@Gender", SqlDbType.Money).Value = t.Gender;
                        cmd.Parameters.AddWithValue("@MaritalStatus", SqlDbType.Money).Value = t.MaritalStatus;
                        cmd.Parameters.AddWithValue("@Email", SqlDbType.Money).Value = t.Email;
                        cmd.Parameters.AddWithValue("@PhoneNumber", SqlDbType.Money).Value = t.PhoneNumber;
                        cmd.Parameters.AddWithValue("@Choice", SqlDbType.Money).Value = Choice;
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Delete(int id)
        {
            try
            {
                string con = "server=SURYA-CHANDRA;Integrated security=true;database=SalaryPrediction;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    string cmd = "delete from Employee.Employee where EmpId = "+id;
                    using (SqlCommand Commnad = new SqlCommand(cmd, connection))
                    {
                        return Commnad.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                List<Employee> Emp = new List<Employee>();
                Employee SoftEmpvm;

                string con = "server=SURYA-CHANDRA;Integrated security=true;database=SalaryPrediction;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    string cmd = "select * from Employee.Employee";
                    using (SqlCommand Commnad = new SqlCommand(cmd, connection))
                    {
                        using (var reader = Commnad.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SoftEmpvm = new Employee();
                                SoftEmpvm.EmpId = Convert.ToInt32(reader["EmpId"]);
                                SoftEmpvm.EmployeeName = Convert.ToString(reader["EmployeeName"]);
                                SoftEmpvm.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                                SoftEmpvm.HireDate = Convert.ToDateTime(reader["HireDate"]);
                                SoftEmpvm.Gender = Convert.ToString(reader["Gender"]);
                                SoftEmpvm.MaritalStatus = Convert.ToString(reader["MaritalStatus"]);
                                SoftEmpvm.Email = Convert.ToString(reader["Email"]);
                                SoftEmpvm.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                                Emp.Add(SoftEmpvm);
                            }
                        }
                    }
                }
                return Emp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Employee> GetEmp(int id)
        {
            try
            {
                List<Employee> Emp = new List<Employee>();
                Employee SoftEmpvm;

                string con = "server=SURYA-CHANDRA;Integrated security=true;database=SalaryPrediction;Trusted_Connection=True;";
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    string cmd = "select * from Employee.Employee where EmpId = " + id;
                    using (SqlCommand Commnad = new SqlCommand(cmd,connection))
                    {
                        using (var reader = Commnad.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SoftEmpvm = new Employee();
                                SoftEmpvm.EmpId = Convert.ToInt32(reader["EmpId"]);
                                SoftEmpvm.EmployeeName = Convert.ToString(reader["EmployeeName"]);
                                SoftEmpvm.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
                                SoftEmpvm.HireDate = Convert.ToDateTime(reader["HireDate"]);
                                SoftEmpvm.Gender = Convert.ToString(reader["Gender"]);
                                SoftEmpvm.MaritalStatus = Convert.ToString(reader["MaritalStatus"]);
                                SoftEmpvm.Email = Convert.ToString(reader["Email"]);
                                SoftEmpvm.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                                Emp.Add(SoftEmpvm);
                            }
                        }
                    }
                }
                return Emp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}