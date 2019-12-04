using System;
using System.Collections.Generic;
using System.Linq;
using GroupWebApplication.Data;
using GroupWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;


namespace GroupWebApplication.Controllers
{
    public class VideoController : Controller
    {
        // GET
        public IActionResult Index()
        {
            String mediaType = "video";
            List<ImageModel> videoModel = new List<ImageModel>();

            using (var context = new AzureImageContext())
            {
                var videos = context.imagedbcontext;

                foreach (var video in videos)
                {
                    if (video.MediaType == mediaType)
                    {
                        videoModel.Add(video);
                    }
                }
            }

            videoModel = videoModel.OrderByDescending(d => d.Date).ToList();

            return View(videoModel);
        }
    }
}