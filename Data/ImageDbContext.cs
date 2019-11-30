using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GroupWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using DbContext = System.Data.Entity.DbContext;

namespace GroupWebApplication.Data
{
    public class ImageDbContext : System.Data.Entity.DbContext
    {
        /*
        public string ConnectionString { get; set; }

        public ImageDbContext(String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public ImageDbContext() : base() { }
        
        public System.Data.Entity.DbSet<ImageModel> ImageDbSet { get; set; }
        
        protected void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }*/
        
    }
}