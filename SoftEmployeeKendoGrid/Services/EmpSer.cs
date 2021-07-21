using SoftEmployeeKendoGrid.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SoftEmployeeKendoGrid.Services
{
    public class EmpSer
    {
        public readonly string _ConnectionString;
        //private readonly IConfiguration _configuration;

        public EmpSer(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public List<SoftEmployee> GetEmp()
        {
            List<SoftEmployee> getResult = new List<SoftEmployee>();
            SoftEmployee SoftEmpvm;

            using (var conn = new SqlConnection(_ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select EmpId,EmpName,EmpSalary,EmpDOB,EmpAddress,EmpStatus from SoftWareEmployee";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SoftEmpvm = new SoftEmployee();
                            SoftEmpvm.EmpId = Convert.ToInt32(reader["EmpId"]);
                            SoftEmpvm.EmpName = Convert.ToString(reader["EmpName"]);
                            SoftEmpvm.EmpSalary = Convert.ToDecimal(reader["EmpSalary"]);
                            SoftEmpvm.EmpDOB = Convert.ToDateTime(reader["EmpDOB"]);
                            SoftEmpvm.EmpAddress = Convert.ToString(reader["EmpAddress"]);
                            SoftEmpvm.EmpStatus = Convert.ToString(reader["EmpStatus"]);
                            getResult.Add(SoftEmpvm);
                        }
                    }
                }
            }
            return getResult;
        }
    }
}
