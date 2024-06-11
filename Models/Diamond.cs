using System.ComponentModel.DataAnnotations;

namespace SWPApp.Models
{
    public class Diamond
    {
        [Key]
        public int DiamondId { get; set; }
        public string Shape { get; set; }
        public decimal CaratWeight { get; set; }
        public string Color { get; set; }
        public bool Status { get; set; }
    }

}
