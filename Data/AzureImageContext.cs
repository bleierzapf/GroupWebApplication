using System;
using System.Configuration;
using GroupWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GroupWebApplication.Data
{
    public class AzureImageContext : DbContext
    {
        
        public DbSet<ImageModel> imagedbcontext { get; set; }

        private static DatabaseConnection dbConnection = new DatabaseConnection();

        private String sqlConnectionString = dbConnection.ConnectionString;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(sqlConnectionString);
        }
    }
}