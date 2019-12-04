using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroupWebApplication.Data;
using GroupWebApplication.Models;

namespace GroupWebApplication.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ImageModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ImageModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageModel>>> GetImageModel()
        {
            return await _context.ImageModel.ToListAsync();
        }

        // GET: api/ImageModels/5
        [HttpGet("{Date}")]
        public async Task<ActionResult<ImageModel>> GetImageModel(string Date)
        {
            var imageModel = await _context.ImageModel.FindAsync(Date);

            if (imageModel == null)
            {
                return NotFound();
            }

            return imageModel;
        }

        private bool ImageModelExists(string Date)
        {
            return _context.ImageModel.Any(e => e.Date == Date);
        }
    }
}
