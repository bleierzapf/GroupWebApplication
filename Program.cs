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
            //MySqlConnect(); //for testing
            dailyImageCall();

            //ImageDbContext db = new ImageDbContext();
            //Console.WriteLine(db.ImageDbSet.Find(0));

            CreateHostBuilder(args).Build().Run();
        }

        private static async Task dailyImageCall()
        {
            await ImageApi.GetDailyImage();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        
        
        //for testing
        private static void MySqlConnect()
        {
            try 
            {
                String sqlConnectionString =
                    "Server=tcp:csd412project.database.windows.net,1433;" +
                    "Initial Catalog=NasaProject;Persist Security Info=False;" +
                    "User ID=bleierzapf;Password=csd412Password;MultipleActiveResultSets=False;" +
                    "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                //using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    Console.WriteLine("\nQuery data example:");

                    connection.Open();       
                    StringBuilder sb = new StringBuilder();
                    
                    sb.Append("select * from imagedbcontext;");
                    
                    /*sb.Append("SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName ");
                    sb.Append("FROM [SalesLT].[ProductCategory] pc ");
                    sb.Append("JOIN [SalesLT].[Product] p ");
                    sb.Append("ON pc.productcategoryid = p.productcategoryid;");*/
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < 7; i++)
                                {
                                    Console.WriteLine(reader.GetValue(i));
                                }
                            }
                        }
                    }                    
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }
    }
}