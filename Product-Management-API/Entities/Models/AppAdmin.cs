using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{ // The Admin entity class inheriting from Identity class
    public class AppAdmin : IdentityUser
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; init; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; }
        [Required(ErrorMessage = "FirstName is required")]
        public string Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Role { get; init; } = "Staff";

    }
}
