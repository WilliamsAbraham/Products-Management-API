using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, ProductName = "Orang", ProductDescription = "sweet", Price = 202, IsEnabled = true},
                new Product {Id = 2, ProductName = "Grape", ProductDescription = "bitter", Price = 200, IsEnabled = false}) ;
        }
    }
}
