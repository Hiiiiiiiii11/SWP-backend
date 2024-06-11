using System.ComponentModel.DataAnnotations;

namespace SWPApp.Models
{
    public class CommitmentRecord
    {
        [Key]
        public int RecordId { get; set; }  // This property can be marked as the primary key
        public int RequestId { get; set; }
        public DateTime CommitDate { get; set; }

        public Request Request { get; set; }
    }
}
