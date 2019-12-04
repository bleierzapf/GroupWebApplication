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
                    if (image.MediaType == mediaType)
                    {
                        imgModel.Add(image);
                    }
                }
            }

            imgModel = imgModel.OrderByDescending(d => d.Date).ToList();

            return View(imgModel);
        }

		[HttpPost]
		public void VoteUp()
		{
			
		}

        /*
        public IActionResult Index()
        {
            String mediaType = "image";
            //var imageVoteModels;

            ImageVoteModel context = new ImageVoteModel();
            {
                
                IQueryable<ImageVoteModel> imageVoteModels = from i in context.imageModel
                    join v in context.voteModel
                        on i.Date equals v.Date
                    orderby i.Date
                    where i.Media_Type == "images"
                    select new ImageVoteModel
                    {
                        Date = i.Date, Explanation = i.Explanation,
                        Hdurl = i.Hdurl, Url = i.Url, Media_Type = i.Media_Type,
                        Title = i.Title, Votes = v.Votes
                    };

                var imageList = imageVoteModels.ToList();

                return View(imageList);
            }
        }*/
    }
}