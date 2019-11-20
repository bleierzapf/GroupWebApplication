using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GroupWebApplication.Models;
using Newtonsoft.Json;

namespace GroupWebApplication.Controllers
{
    public class ImageApi
    {
        public static ImageModel DailyImage = new ImageModel();

        public static async Task GetDailyImage()
        {
            String dailyPath = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";
            try
            {
                DailyImage = await GetImageAsync(DailyImage, dailyPath);
                DailyImageToDataTable(DailyImage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        private static void DailyImageToDataTable(ImageModel dailyImage)
        {
            DataTable imageTable = new DataTable();
            imageTable.Columns.Add("Pk", typeof(int));
            imageTable.Columns.Add("Date", typeof(DateTime));
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
        }
        
        static async Task<ImageModel> GetImageAsync(ImageModel imageModel, String path)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync(path);
            imageModel = JsonConvert.DeserializeObject<ImageModel>(response);
            return imageModel;
        }
        
        //write to console for testing
        public static void ShowImageModel(ImageModel imageModel)
        {
            Console.WriteLine($"Date: {imageModel.Date}\n" +
                          $"Title: {imageModel.Title}\n" +
                          $"Media Format: {imageModel.Media_Type}\n" +
                          $"Explanation: {imageModel.Explanation}\n" +
                          $"URL: {imageModel.Url}\n" +
                          $"HD URL: {imageModel.Hdurl}");
        }
    }
}