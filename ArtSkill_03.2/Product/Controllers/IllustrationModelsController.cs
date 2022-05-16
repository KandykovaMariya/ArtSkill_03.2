using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtSkill_03._2.Domain;
using ArtSkill_03._2.Models;

namespace ArtSkill_03._2.Product.Controllers
{
    public class IllustrationModelsController : Controller
    { 
        private readonly AppDbContext _context;

        public IllustrationModelsController(AppDbContext context)
        {
            _context = context;
        }
       

        // GET: IllustrationModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.IllustrationModels.ToListAsync());
        }

        // GET: IllustrationModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var illustrationModel = await _context.IllustrationModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (illustrationModel == null)
            {
                return NotFound();
            }

            return View(illustrationModel);
        }

        // GET: IllustrationModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IllustrationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,shortDesc,longDesc,ImgProduct,Price")] IllustrationModel illustrationModel)
        {
            if (ModelState.IsValid)
            {
                illustrationModel.Id = Guid.NewGuid();
                _context.Add(illustrationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(illustrationModel);
        }

        // GET: IllustrationModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var illustrationModel = await _context.IllustrationModels.FindAsync(id);
            if (illustrationModel == null)
            {
                return NotFound();
            }
            return View(illustrationModel);
        }

        // POST: IllustrationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,shortDesc,longDesc,ImgProduct,Price")] IllustrationModel illustrationModel)
        {
            if (id != illustrationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(illustrationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IllustrationModelExists(illustrationModel.Id))
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
            return View(illustrationModel);
        }

        // GET: IllustrationModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var illustrationModel = await _context.IllustrationModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (illustrationModel == null)
            {
                return NotFound();
            }

            return View(illustrationModel);
        }

        // POST: IllustrationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var illustrationModel = await _context.IllustrationModels.FindAsync(id);
            _context.IllustrationModels.Remove(illustrationModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IllustrationModelExists(Guid id)
        {
            return _context.IllustrationModels.Any(e => e.Id == id);
        }
    }
}
