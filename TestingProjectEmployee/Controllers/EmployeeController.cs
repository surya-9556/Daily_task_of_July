using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestingProjectEmployee.EmployeeService;
using TestingProjectEmployee.Models;

namespace TestingProjectEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController()
        {
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmployeeData()
        {
            SoftEmployee emp = new SoftEmployee();
            List<Employee> result = (List<Employee>)emp.GetAll();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}