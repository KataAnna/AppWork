using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWork.Data;
using AppWork.Models;

namespace AppWork.Controllers
{
    public class ProektsController : Controller
    {
        private readonly ManagerContext _context;

        public ProektsController(ManagerContext context)
        {
            _context = context;
        }

        // GET: Proekts
        public async Task<IActionResult> Index()
        {
            var proekts = _context.Proekts
                .Include(c => c.Managers)
                .AsNoTracking();
            return View(await proekts.ToListAsync());
        }

        // GET: Proekts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proekt = await _context.Proekts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proekt == null)
            {
                return NotFound();
            }

            return View(proekt);
        }

        // GET: Proekts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proekts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectName,NumberOfWorkers")] Proekt proekt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proekt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proekt);
        }

        // GET: Proekts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proekt = await _context.Proekts.FindAsync(id);
            if (proekt == null)
            {
                return NotFound();
            }
            return View(proekt);
        }

        // POST: Proekts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectName,NumberOfWorkers")] Proekt proekt)
        {
            if (id != proekt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proekt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProektExists(proekt.Id))
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
            return View(proekt);
        }

        // GET: Proekts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proekt = await _context.Proekts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proekt == null)
            {
                return NotFound();
            }

            return View(proekt);
        }

        // POST: Proekts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proekt = await _context.Proekts.FindAsync(id);
            _context.Proekts.Remove(proekt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProektExists(int id)
        {
            return _context.Proekts.Any(e => e.Id == id);
        }
    }
}
