using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GroupWebApplication.Models;
using Newtonsoft.Json;

namespace GroupWebApplication.Controllers
{
    public class ImageApi
    {
        public static async Task<ImageModel> GetImageAsync(ImageModel imageModel, String path)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync(path);
            imageModel = JsonConvert.DeserializeObject<ImageModel>(response);
            return imageModel;
        }
        
        //write to concole for testing
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