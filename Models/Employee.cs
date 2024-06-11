using System.ComponentModel.DataAnnotations;

namespace SWPApp.Models
{
    // Models/Employee.cs
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public bool Status { get; set; }
    }

}
