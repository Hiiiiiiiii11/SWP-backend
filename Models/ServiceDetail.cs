using System.ComponentModel.DataAnnotations;

namespace SWPApp.Models
{
    public class ServiceDetail
    {
        [Key]
        public string ServiceId { get; set; }
        public string AssessmentStep { get; set; }
        public string StepDetail { get; set; }

        public Service Service { get; set; }
    }

}
