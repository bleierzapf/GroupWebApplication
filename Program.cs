using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupWebApplication.Controllers;
using GroupWebApplication.Data;
using GroupWebApplication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GroupWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Controllers.ImageApi.GetDailyImage();
            //ImageDbContext db = new ImageDbContext();
            //Console.WriteLine(db.ImageDbSet.Find(0));
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

    }
}