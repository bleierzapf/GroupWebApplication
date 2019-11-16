using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupWebApplication.Controllers;
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
            CreateHostBuilder(args).Build().Run();
            GetDailyImage();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        
        static async Task GetDailyImage()
        {
            String dailyPath = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";
            ImageModel dailyImage = new ImageModel();
            try
            {
                dailyImage = await Controllers.ImageApi.GetImageAsync(dailyImage, dailyPath);
                Controllers.ImageApi.ShowImageModel(dailyImage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

        }
        
    }
}