using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            //Seeding the Admin table with the manger User.
            builder.HasData(
                new AppAdmin { FirstName = "Abraham", LastName = "Williams", Password = "AB123", Email = "willingtoexcel@gmail.com", Role = "Manager" });
                
        }

        
    }
}
