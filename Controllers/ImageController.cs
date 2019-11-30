using System;
using System.Collections.Generic;
using System.Linq;
using GroupWebApplication.Data;
using GroupWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroupWebApplication.Controllers
{
    public class ImageController : Controller
    {
        // GET
        public IActionResult Index()
        {
            String mediaType = "image";
            List<ImageModel> imgModel = new List<ImageModel>();

            using (var context = new AzureImageContext())
            {
                var images = context.imagedbcontext;

                foreach (var image in images)
                {
                    if (image.Media_Type == mediaType)
                    {
                        imgModel.Add(image);
                    }
                }
            }

            imgModel = imgModel.OrderByDescending(d => d.Date).ToList();

            return View(imgModel);
        }
    }
}