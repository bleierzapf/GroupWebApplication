using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupWebApplication.Data;
using GroupWebApplication.Models;

namespace GroupWebApplication.Controllers
{
    public class ImageModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ImageModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ImageModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ImageModel.ToListAsync());
        }

        // GET: ImageModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.ImageModel
                .FirstOrDefaultAsync(m => m.Date == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // GET: ImageModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImageModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Explanation,Media_Type,Title,Url,Hdurl")] ImageModel imageModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imageModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }

        // GET: ImageModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.ImageModel.FindAsync(id);
            if (imageModel == null)
            {
                return NotFound();
            }
            return View(imageModel);
        }

        // POST: ImageModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Date,Explanation,Media_Type,Title,Url,Hdurl")] ImageModel imageModel)
        {
            if (id != imageModel.Date)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageModelExists(imageModel.Date))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(imageModel);
        }

        // GET: ImageModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageModel = await _context.ImageModel
                .FirstOrDefaultAsync(m => m.Date == id);
            if (imageModel == null)
            {
                return NotFound();
            }

            return View(imageModel);
        }

        // POST: ImageModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var imageModel = await _context.ImageModel.FindAsync(id);
            _context.ImageModel.Remove(imageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageModelExists(string id)
        {
            return _context.ImageModel.Any(e => e.Date == id);
        }
    }
}
