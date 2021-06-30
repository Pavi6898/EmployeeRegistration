using EmployeeRegistration.Models;
using EmployeeRegistration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeRegistration.Controllers
{
    public class HomeController : Controller
    {
        public EmployeeS e = new EmployeeS();
              
       // GET: Employee
        [HttpGet]
        [ActionName("EmployeeDetails")]
        public JsonResult Get()
        {
            var Employee = e.EmployeeDetails();
            return Json(new { Employee = Employee }, JsonRequestBehavior.AllowGet);
        }
        // GET: EmployeeById

        [HttpGet]
        [ActionName("EmployeeDetailsById")]
        public JsonResult Get(int Id)
        {
            var Employee = e.EmployeeDetailsById(Id);
            return Json(new { Employee = Employee }, JsonRequestBehavior.AllowGet);
        }

        // post: Employee

        [HttpPost]
       // [ActionName("CreateEmployee")]
        public void CreateEmployee(Employee employee)
        {
            e.CreateEmployee(employee);
        }
        // put: Employee

        [HttpPut]
      // [ActionName("EditEmployee")]
        public void EditEmployee(Employee employee)
        {
            e.EditEmployee(employee);
        }
        // Delete: Employee

        [HttpDelete]
        //[ActionName("DeleteEmployee")]
        public void DeleteEmployee(int Id)
        {
            e.DeleteEmployee(Id);
        }
        // GeT

        [HttpGet]
        [ActionName("DirectReportees")]
        public JsonResult DirectReportees(int Id)
        {
            var Employee = e.DirectReportees(Id);
            return Json(new { Employee = Employee }, JsonRequestBehavior.AllowGet);
        }
        // GET
        [HttpGet]
        [ActionName("InDirectReportees")]
        public JsonResult InDirectReportees(int Id)
        {
            var Employee = e.InDirectReportees(Id);
            return Json(new { Employee = Employee }, JsonRequestBehavior.AllowGet);
        }
     }
}
