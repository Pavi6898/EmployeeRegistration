using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeRegistration.Models
{
    public class Emp
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }
        public int ReportsTo { get; set; }

    }
}