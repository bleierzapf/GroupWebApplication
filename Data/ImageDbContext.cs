using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GroupWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = System.Data.Entity.DbContext;

namespace GroupWebApplication.Data
{
    public class ImageDbContext : DbContext
    {
        public ImageDbContext() : base("ImageDbContext") { }
        
        public System.Data.Entity.DbSet<ImageModel> ImageDbSet { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
    }
}