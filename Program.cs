using System;
using System.Data.SqlClient;
using System.Text;
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
using SqlConnection = System.Data.SqlClient.SqlConnection;

namespace GroupWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            dailyImageCall();
            CreateHostBuilder(args).Build().Run();
        }

        private static async Task dailyImageCall()
        {
            await ImageApi.GetDailyImage();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

    }
}