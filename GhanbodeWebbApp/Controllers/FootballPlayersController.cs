using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GhanbodeWebbApp.Models;

namespace GhanbodeWebbApp.Controllers
{
    public class FootballPlayersController : Controller
    {
        private readonly GhanbodeWebbAppContext _context;

        public FootballPlayersController(GhanbodeWebbAppContext context)
        {
            _context = context;
        }

        // GET: FootballPlayers
        public async Task<IActionResult> Index()
        {
            return View(await _context.FootballPlayers.ToListAsync());
        }

        // GET: FootballPlayers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballPlayers = await _context.FootballPlayers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballPlayers == null)
            {
                return NotFound();
            }

            return View(footballPlayers);
        }

        // GET: FootballPlayers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FootballPlayers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Nationality,Age,Price,Description")] FootballPlayers footballPlayers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(footballPlayers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(footballPlayers);
        }

        // GET: FootballPlayers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballPlayers = await _context.FootballPlayers.FindAsync(id);
            if (footballPlayers == null)
            {
                return NotFound();
            }
            return View(footballPlayers);
        }

        // POST: FootballPlayers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Nationality,Age,Price,Description")] FootballPlayers footballPlayers)
        {
            if (id != footballPlayers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footballPlayers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootballPlayersExists(footballPlayers.Id))
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
            return View(footballPlayers);
        }

        // GET: FootballPlayers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footballPlayers = await _context.FootballPlayers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballPlayers == null)
            {
                return NotFound();
            }

            return View(footballPlayers);
        }

        // POST: FootballPlayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var footballPlayers = await _context.FootballPlayers.FindAsync(id);
            _context.FootballPlayers.Remove(footballPlayers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootballPlayersExists(int id)
        {
            return _context.FootballPlayers.Any(e => e.Id == id);
        }
    }
}
