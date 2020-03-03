using System;
using System.Configuration;
using System.Data.Common;
using System.Runtime.InteropServices;
using GroupWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GroupWebApplication.Data
{
    public class AzureVoteContext : DbContext
    {
        public DbSet<VoteModel> Votedbcontext { get; set; }
        
        private static DatabaseConnection _dbConnection = new DatabaseConnection();
        
        String _sqlConnectionString = _dbConnection.ConnectionString;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_sqlConnectionString);
        }
    }
}