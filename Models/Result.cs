using System.ComponentModel.DataAnnotations;

namespace SWPApp.Models
{
    public class Result
    {
        [Key]
        public int ResultId { get; set; }
        public int DiamondId { get; set; }
        public int RequestId { get; set; }
        public string DiamondOrigin { get; set; }
        public string Shape { get; set; }
        public string Measurements { get; set; }
        public decimal CaratWeight { get; set; }
        public string Color { get; set; }
        public string Clarity { get; set; }
        public string Cut { get; set; }
        public string Proportions { get; set; }
        public string Polish { get; set; }
        public string Symmetry { get; set; }
        public string Fluorescence { get; set; }

        public Request Request { get; set; }
        public Diamond Diamond { get; set; }
    }

}
