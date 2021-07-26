using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingProjectEmployee.EmployeeService;
using TestingProjectEmployee.Models;

namespace TestingProjectEmployee.Tests
{
    [TestClass]
    public class EmployeeModelTest
    {
        [TestMethod]
        public void EmployeeModel()
        {
            //Arrange
            SoftEmployee SE = new SoftEmployee();
            int id = 103;

            //Act
            var Result = SE.GetEmp(id);

            //Assert
            Assert.AreEqual(1,Result.Count());
        }

        [TestMethod]
        public void EmployeeName()
        {
            //Arrange
            SoftEmployee SE = new SoftEmployee();
            int id = 101;
            string Name = "G Dhreej venkata phani sai krishna";

            //Act
            var Result = SE.GetEmp(id);
            var List = Result.Select(i => i.EmployeeName).FirstOrDefault();

            //Assert
            Assert.AreEqual(Name,List);
        }

        [TestMethod]
        public void DeleteEmployee()
        {
            //Arrange
            SoftEmployee SE = new SoftEmployee();
            int id = 113;

            //Act
            var Result = SE.Delete(id);

            //Assert
            Assert.IsNotNull(Result);
        }

        [TestMethod]
        public void DeleteingNotExistingEmployee()
        {
            //Arrange
            SoftEmployee SE = new SoftEmployee();
            int id = 113;

            //Act
            var Result = SE.Delete(id);

            //Assert
            Assert.AreEqual(0,Result);
        }

        [TestMethod]
        public void AddEmployee()
        {
            //Arrange
            SoftEmployee SE = new SoftEmployee();
            Employee emp = new Employee()
                {
                EmployeeName="R SaiNath Reddy",
                BirthDate = DateTime.Now.Date,
                HireDate = DateTime.Now.Date,
                Gender ="M",
                MaritalStatus="S",
                Email="sainathadhoma@gamil.com",
                PhoneNumber="9922883344"
            };

            //Act
            var Result = SE.Add(emp);

            //Assert
            Assert.IsNotNull(Result);
        }

        [TestMethod]
        public void GetAllEmployee()
        {
            //Arrange
            SoftEmployee Emp = new SoftEmployee();

            //Act
            var Result = Emp.GetAll();

            //Assert
            Assert.AreNotEqual(15, Result.Count());
        }
    }
}
