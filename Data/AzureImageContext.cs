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
        
        //public DbSet<VoteModel> votedbcontext { get; set; }
        //public DbSet<ImageVoteModel> imagevotedbcontext { get; set; }

        private static DatabaseConnection _dbConnection = new DatabaseConnection();

        private String _sqlConnectionString = _dbConnection.ConnectionString;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_sqlConnectionString);
        }
    }
}