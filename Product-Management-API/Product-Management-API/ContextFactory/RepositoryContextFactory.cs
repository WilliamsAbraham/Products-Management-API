﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;

namespace Product_Management_API.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>

    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseMySql(configuration.GetConnectionString("SqlConnection"),
            new MySqlServerVersion(new Version(8, 0, 11)), b => b.MigrationsAssembly("Product-Management-API"));
            return new RepositoryContext(builder.Options);

        }
    }
}
