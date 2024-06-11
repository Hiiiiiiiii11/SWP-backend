using System.ComponentModel.DataAnnotations;

namespace SWPApp.Models
{
    public class Certificate
    {
        [Key]
        public int CertificateId { get; set; }
        public int ResultId { get; set; }
        public DateTime IssueDate { get; set; }

        public Result Result { get; set; }
    }
}
