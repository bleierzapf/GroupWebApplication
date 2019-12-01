using System.Threading.Tasks;
using GroupWebApplication.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GroupWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DailyImageCall();

            CreateHostBuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        
        private static async Task DailyImageCall()
        {
            await ImageApi.GetDailyImage();
        }
    }
}