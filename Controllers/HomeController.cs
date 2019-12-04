using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using GroupWebApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GroupWebApplication.Models;

namespace GroupWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            String todayDate = DateTime.Today.ToString("yyyy-MM-dd");
            ImageModel imgModel;

            using (var context = new AzureImageContext())
            {
                imgModel = context.imagedbcontext.Single(a => a.Date == todayDate);

                while (imgModel.MediaType == "video")
                {
                    var i = -1;
                    String adjDate = DateTime.Today.AddDays(i).ToString("yyyy-MM-dd");
                    imgModel = context.imagedbcontext.Single(a => a.Date == adjDate);
                    i--;
                }
            }

            return View(imgModel);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}