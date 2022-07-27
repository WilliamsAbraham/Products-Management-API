using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{ // The Admin entity class inheriting from Identity class
    public class AppAdmin : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
