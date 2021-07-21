using GridApplication.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GridApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private masterEntities Master;

        public EmployeeController()
        {
            Master = new masterEntities();
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BindData([DataSourceRequest] DataSourceRequest request)
        {
            IEnumerable<SoftWareEmployee> softWares = (from i in Master.SoftWareEmployees
                                                       select new SoftWareEmployee
                                                       {
                                                           EmpId = i.EmpId,
                                                           EmpName = i.EmpName,
                                                           EmpSalary = i.EmpSalary,
                                                           EmpDOB = i.EmpDOB,
                                                           EmpAddress = i.EmpAddress,
                                                           EmpStatus = i.EmpStatus
                                                       }).ToList();
            return Json(softWares.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}