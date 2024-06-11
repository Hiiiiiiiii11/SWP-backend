using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWPApp.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SWPApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DiamondAssesmentSystemDBContext _context;

        public CustomerController(DiamondAssesmentSystemDBContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.Customers.Any(c => c.Email == model.Email))
            {
                return BadRequest("Email is already registered");
            }

            var hashedPassword = HashPassword(model.Password);

            var customer = new Customer
            {
                Email = model.Email,
                Password = hashedPassword,
                Status = true
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var hashedPassword = HashPassword(loginModel.Password);

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == loginModel.Email && c.Password == hashedPassword);

            if (customer == null)
            {
                return Unauthorized("Invalid email or password");
            }

            var loginToken = GenerateToken();
            customer.LoginToken = loginToken;
            customer.LoginTokenExpires = DateTime.UtcNow.AddMinutes(1); // Token expires in 1 minute
            await _context.SaveChangesAsync();

            return Ok(new { Token = loginToken });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == model.Email);
            if (customer == null)
            {
                return BadRequest("Email not found");
            }

            var token = GenerateToken();
            customer.ResetToken = token;
            customer.ResetTokenExpires = DateTime.UtcNow.AddMinutes(1); // Token expires in 1 minute

            await _context.SaveChangesAsync();

            return Ok("Password reset token has been sent to your email.");
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == model.Email);
            if (customer == null || customer.ResetToken != model.Token || customer.ResetTokenExpires < DateTime.UtcNow)
            {
                return BadRequest("Invalid token or token expired.");
            }

            if (model.NewPassword != model.ConfirmPassword)
            {
                return BadRequest("Passwords do not match.");
            }

            customer.Password = HashPassword(model.NewPassword);
            customer.ResetToken = null;
            customer.ResetTokenExpires = null;
            await _context.SaveChangesAsync();

            return Ok("Password reset successful.");
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private string GenerateToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}