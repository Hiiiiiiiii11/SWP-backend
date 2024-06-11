using System.ComponentModel.DataAnnotations;

namespace SWPApp.Models
{
    public class SealingRecord
    {
        [Key]
        public int SealingId { get; set; }
        public int RequestId { get; set; }
        public DateTime SealDate { get; set; }

        public Request Request { get; set; }
    }
}
