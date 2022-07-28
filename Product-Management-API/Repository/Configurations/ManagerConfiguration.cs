using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configurations
{
    public class ManagerConfiguration
    {
        public void Configure(EntityTypeBuilder<AppAdmin> builder)
        {
            //Seeding the Admin table with the manger User.
            builder.HasData(
                new AppAdmin { FirstName = "Abraham", LastName = "Williams", Password = "AB123", Email = "willingtoexcel@gmail.com", Role = "Manager" });
                
        }
    }
}
