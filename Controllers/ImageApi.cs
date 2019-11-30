using System;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using GroupWebApplication.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text;

namespace GroupWebApplication.Controllers
{
    public class ImageApi
    {
        private static ImageModel _dailyImage = new ImageModel();

        public static async Task GetDailyImage()
        {
            var rand = new Random();
            try
            {
                //random information gathering
                //var month = rand.Next(1, 13); 
                //var day = rand.Next(1, 30);  
                //var year = rand.Next(2015, 2020);
                //String date = "&date=" + year + "-" + month + "-" + day;

                String dailyPath = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";

                _dailyImage = await GetImageAsync(_dailyImage, dailyPath);
                ImageToDb(_dailyImage);
            }
            catch (Exception e) 
            { 
                Console.WriteLine(e.Message); 
            }
            
            Console.ReadLine();
            
            
        }

        private static void ImageDbToModel()
        {
            try
            {
                String sqlConnectionString =
                    "Server=tcp:csd412project.database.windows.net,1433;" +
                    "Initial Catalog=NasaProject;Persist Security Info=False;" +
                    "User ID=bleierzapf;Password={dbconnection};MultipleActiveResultSets=False;" +
                    "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                
                
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }

        private static void ImageToDb(ImageModel dailyImage)
        { 
            try 
            {
                String sqlConnectionString =
                    "Server=tcp:csd412project.database.windows.net,1433;" +
                    "Initial Catalog=NasaProject;Persist Security Info=False;" +
                    "User ID=bleierzapf;Password=csd412Password;MultipleActiveResultSets=False;" +
                    "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    StringBuilder sb = new StringBuilder();
                    
                    sb.Append("INSERT INTO [imagedbcontext] ");
                    sb.Append("VALUES ('");
                    sb.Append(dailyImage.Date + "', '");

                    dailyImage.Explanation = ApostropheFix(dailyImage.Explanation);
                    sb.Append(dailyImage.Explanation + "', '");
                    sb.Append(dailyImage.Media_Type + "', '");
                    
                    dailyImage.Title = ApostropheFix(dailyImage.Title);
                    sb.Append(dailyImage.Title + "', '");
                    sb.Append(dailyImage.Url + "', '");
                    sb.Append(dailyImage.Hdurl + "');");
                    
                    String sql = sb.ToString();
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                        connection.Close();
                    } 
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }

        private static String ApostropheFix(String checkString)
        {
            if (checkString.Contains("'"))
            {
                return checkString.Replace("'", "''");
            }

            return checkString;
        }
        
        static async Task<ImageModel> GetImageAsync(ImageModel imageModel, String path)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(path);
            imageModel = JsonConvert.DeserializeObject<ImageModel>(response);
            return imageModel;
        }
        
       
        // do be removed
        /*
        private static void DailyImageToDataTable(ImageModel dailyImage)
        {
            DataTable imageTable = new DataTable();
            imageTable.Columns.Add("Pk", typeof(int));
            imageTable.Columns.Add("Date", typeof(String));
            imageTable.Columns.Add("Explanation", typeof(String));
            imageTable.Columns.Add("Media_Type", typeof(String));
            imageTable.Columns.Add("Title", typeof(String));
            imageTable.Columns.Add("Url", typeof(String));
            imageTable.Columns.Add("Hdurl", typeof(String));

            DataRow dr = imageTable.NewRow();
            dr["Pk"] = 0;
            dr["Date"] = dailyImage.Date;
            dr["Explanation"] = dailyImage.Explanation;
            dr["Media_Type"] = dailyImage.Media_Type;
            dr["Title"] = dailyImage.Title;
            dr["Url"] = dailyImage.Url;
            dr["Hdurl"] = dailyImage.Hdurl;
            
            Console.WriteLine("From Table " + dailyImage.Url);
        } */
        
        //write to console for testing
        /*public static void ShowImageModel(ImageModel imageModel)
        {
            Console.WriteLine($"Date: {imageModel.Date}\n" +
                          $"Title: {imageModel.Title}\n" +
                          $"Media Format: {imageModel.Media_Type}\n" +
                          $"Explanation: {imageModel.Explanation}\n" +
                          $"URL: {imageModel.Url}\n" +
                          $"HD URL: {imageModel.Hdurl}");
        }*/
    }
}