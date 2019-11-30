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
    }
}