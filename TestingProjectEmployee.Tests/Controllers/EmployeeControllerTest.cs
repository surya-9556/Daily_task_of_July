using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestingProjectEmployee.Controllers;

namespace TestingProjectEmployee.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestMethod]
        public void GetIndex()
        {
            //Arrange
            EmployeeController emp = new EmployeeController();

            //Act
            ViewResult result = emp.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAllListOfEmployee()
        {
            //Arrange
            EmployeeController emp = new EmployeeController();

            //Act
            var results = emp.GetEmployeeData();

            //Assert
            Assert.IsNotNull(results);
        }
    }
}
