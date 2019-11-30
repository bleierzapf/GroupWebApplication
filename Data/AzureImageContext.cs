using System;
using GroupWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GroupWebApplication.Data
{
    public class AzureImageContext : DbContext
    {
        public DbSet<ImageModel> imagedbcontext { get; set; }

        /*
        String sqlConnectionString =
            "Server=tcp:csd412project.database.windows.net,1433;" +
            "Initial Catalog=NasaProject;Persist Security Info=False;" +
            "User ID=bleierzapf;Password={dbconnection};MultipleActiveResultSets=False;" +
            "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(sqlConnectionString);
        }*/
    }
}