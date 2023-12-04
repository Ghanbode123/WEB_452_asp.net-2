using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPlaystations.Models;

namespace MvcPlaystations.Controllers
{
    public class MvcPlaystationsController : Controller
    {
        private readonly MvcPlaystationsContext _context;

        public MvcPlaystationsController(MvcPlaystationsContext context)
        {
            _context = context;
        }

        // GET: MvcPlaystations
        
        public async Task<IActionResult> Index(string searchString, string searchBy)
        {
             var playstations = from p in _context.Playstations
                               select p;
            if (searchBy == "RELEASEDATE") 
            {
                if (DateTime.TryParse(searchString, out var date))
                {
                    playstations = playstations.Where(p => p.ReleaseDate.Date == date.Date);
                }
            }      
            else if (searchBy == "MANUFACTURER")
            {
                playstations = playstations.Where(p => p .Manufacturer.Contains(searchString));
            }  
            else if (searchBy == "PRICE")
            {
                if (decimal.TryParse(searchString, out var price))
                {
                    playstations = playstations.Where(p => p.Price == price);
                }
            }        
            return View(await _context.Playstations.ToListAsync());
        }

        // GET: MvcPlaystations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playstations = await _context.Playstations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playstations == null)
            {
                return NotFound();
            }

            return View(playstations);
        }

        // GET: MvcPlaystations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MvcPlaystations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModelName,Manufacturer,StorageCapacityGB,Price,ReleaseDate,Version,Colour")] Playstations playstations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playstations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playstations);
        }

        // GET: MvcPlaystations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playstations = await _context.Playstations.FindAsync(id);
            if (playstations == null)
            {
                return NotFound();
            }
            return View(playstations);
        }

        // POST: MvcPlaystations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModelName,Manufacturer,StorageCapacityGB,Price,ReleaseDate,Version,Colour")] Playstations playstations)
        {
            if (id != playstations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playstations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaystationsExists(playstations.Id))
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
            return View(playstations);
        }

        // GET: MvcPlaystations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playstations = await _context.Playstations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playstations == null)
            {
                return NotFound();
            }

            return View(playstations);
        }

        // POST: MvcPlaystations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playstations = await _context.Playstations.FindAsync(id);
            _context.Playstations.Remove(playstations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Hidden ()
        {
            var hiddenPlaystations = await _context.Playstations.Where(p => p.IsHidden). ToListAsync();
            return View(hiddenPlaystations);
        }
        public async Task<IActionResult> ReturnHiddenPlaystations()
        {
            var hiddenPlaystations = await _context.Playstations.Where(p => p.IsHidden). ToListAsync();
            foreach (var Playstations in hiddenPlaystations)
            {
                Playstations.IsHidden = false;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteAll()
        {
            return View();
        }
        [HttpPost, ActionName("DeleteAll")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAll()
        {
            var allPlaystations = _context.Playstations.ToList();
            if (allPlaystations.Count > 0)
            {
                _context.Playstations.RemoveRange(allPlaystations);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PlaystationsExists(int id)
        {
            return _context.Playstations.Any(e => e.Id == id);
        }
    }
}
