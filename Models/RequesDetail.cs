using System.ComponentModel.DataAnnotations;

namespace SWPApp.Models
{
    public class RequestDetail
    {
        [Key]
        public int RequestId { get; set; }
        public string ServiceId { get; set; }
        public string PaymentStatus { get; set; }
        public int PaymentMethod { get; set; }

        public Request Request { get; set; }
        public Service Service { get; set; }
    }

}
