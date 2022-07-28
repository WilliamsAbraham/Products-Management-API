using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
                    builder.HasData(
          new IdentityRole
          {
              Name = "Manager",
              NormalizedName = "MANAGER"
          },
          new IdentityRole
          {
              Name = "Staff",
              NormalizedName = "ADMINISTRATOR"
          }
          );
        }
    }
}
