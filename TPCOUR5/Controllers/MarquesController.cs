using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TPCOUR5;
using TPCOUR5.Models;
using TPCOUR5.Request;

namespace TPCOUR5.Controllers
{
    [Authorize]
    public class MarquesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MarquesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Marques
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marques.ToListAsync());
        }

        // GET: Marques/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marque = await _context.Marques
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marque == null)
            {
                return NotFound();
            }

            return View(marque);
        }

        // GET: Marques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] CreateOrUpdateMarque marque)
        {
            if (ModelState.IsValid)
            {
                marque.Id = Guid.NewGuid();
                var creer = new Marque
                {
                    Id = marque.Id,
                    Name = marque.Name,
                    Description = marque.Description,
                };
                _context.Add(creer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marque);
        }

        // GET: Marques/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marque = await _context.Marques.FindAsync(id);
            if (marque == null)
            {
                return NotFound();
            }
            return View(marque);
        }

        // POST: Marques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] CreateOrUpdateMarque marque)
        {
            if (id != marque.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var update = new Marque
                    {
                        Id = marque.Id,
                        Name = marque.Name,
                        Description = marque.Description,
                    };
                    _context.Update(update);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarqueExists(marque.Id))
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
            return View(marque);
        }

        // GET: Marques/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marque = await _context.Marques
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marque == null)
            {
                return NotFound();
            }

            return View(marque);
        }

        // POST: Marques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var marque = await _context.Marques.FindAsync(id);
            if (marque != null)
            {
                _context.Marques.Remove(marque);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarqueExists(Guid id)
        {
            return _context.Marques.Any(e => e.Id == id);
        }
    }
}
