using EmployeeRegistration.Models;
using EmployeeRegistration.Services;
//using Microsoft.AspNetCore.Cors;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeRegistration.Controllers
{
    public class EmployeeController : ApiController
    {
        public EmployeeS e = new EmployeeS();

        // GET: Employee
        [HttpGet]
        [ActionName("EmployeeDetails")]
        public IHttpActionResult Get()
        {
            var Employee = e.EmployeeDetails();
            return Ok(Employee);
        }
        // GET: EmployeeById

        [HttpGet]
        [ActionName("EmployeeDetailsById")]
        public IHttpActionResult Get(int Id)
        {
            var Employee = e.EmployeeDetailsById(Id);
            return Ok(Employee);
                }

        // post: Employee

        [EnableCors(origins: "http://localhost:8083", headers: "*", methods: "*")]
        [HttpPost]
        // [ActionName("CreateEmployee")]
        public IHttpActionResult CreateEmployee(Emp employee)
        {
            e.CreateEmployee(employee);
            return Ok();
        }
        // put: Employee
       [EnableCors(origins: "http://localhost:8083", headers: "*", methods: "*")]
        [HttpPut]
        // [ActionName("EditEmployee")]
        public IHttpActionResult EditEmployee(Employee employee)
        {
            e.EditEmployee(employee);
            return Ok();
        }

        // Delete: Employee
        [EnableCors(origins: "http://localhost:8083", headers: "*", methods: "*")]
        [HttpDelete]
        [ActionName("DeleteEmployee")]
        public IHttpActionResult DeleteEmployee(int Id)
        {
            e.DeleteEmployee(Id);
            return Ok();
        }
        // GeT

        [HttpGet]
        [ActionName("DirectReportees")]
        public IHttpActionResult DirectReportees(int Id)
        {
            var Employee = e.DirectReportees(Id);
            return Ok(Employee);
        }
        // GET
        [HttpGet]
        [ActionName("InDirectReportees")]
        public IHttpActionResult InDirectReportees(int Id)
        {
            var Employee = e.InDirectReportees(Id);
            return Ok(Employee);
        }
    }
}
