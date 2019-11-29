using System;
using System.Threading.Tasks;
using GroupWebApplication.Data;
using Microsoft.AspNetCore.Mvc;

namespace GroupWebApplication.Controllers
{
    public class ImageController : Controller
    {
        private readonly AzureImageContext _imageContext;

        public ImageController(AzureImageContext context)
        {
            _imageContext = context;
        }
        /*
        public async Task<IActionResult> homeImage(long? id)
        {
            var imageId = DateTime.Today.ToString("yyyy-MM-dd");

        }*/
    }
}