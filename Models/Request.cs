using System.ComponentModel.DataAnnotations;

namespace SWPApp.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RequestDate { get; set; }
        public string ServiceType { get; set; }
        public int EmployeeId { get; set; }
        public int? DiamondId { get; set; }
        public string ServiceId { get; set; }
        public bool Status { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Diamond Diamond { get; set; }
    }
}
