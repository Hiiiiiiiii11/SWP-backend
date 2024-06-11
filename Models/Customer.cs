using System.ComponentModel.DataAnnotations;

namespace SWPApp.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string? CustomerName { get; set; }  // Nullable string for CustomerName

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        [Phone]
        public string? Phone { get; set; } // Nullable string for Phone

        public string? IDcard { get; set; } // Nullable string for IDcard

        public string? Address { get; set; }  // Nullable string for Address

        public bool Status { get; set; } // Non-nullable boolean for Status

        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }

        public string? LoginToken { get; set; }
        public DateTime? LoginTokenExpires { get; set; } // Expiration time for the login token
    }
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class ResetPasswordModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and contain at least one number and one special character.")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
