using System.ComponentModel.DataAnnotations;

namespace SWPApp.Models
{
    public class Service
    {
        [Key]
        public string ServiceId { get; set; }
        public string ServiceType { get; set; }
        public string Description { get; set; }
        public decimal ServicePrice { get; set; }
        public int Duration { get; set; }
    }

}
