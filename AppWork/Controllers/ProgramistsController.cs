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
    public class ProgramistsController : Controller
    {
        private readonly ManagerContext _context;

        public ProgramistsController(ManagerContext context)
        {
            _context = context;
        }

        // GET: Programists
        public async Task<IActionResult> Index(
            string sortOrder, 
            string searchString, 
            string currentFilter, 
            int? pageNumber)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var programist = from s in _context.Programists
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                programist = programist.Where(s => s.Surname.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    programist = programist.OrderByDescending(s => s.Surname);
                    break;
                case "date":
                    programist = programist.OrderBy(s => s.Email);
                    break;
                case "date_desc":
                    programist = programist.OrderByDescending(s => s.Email);
                    break;
                default:
                    programist = programist.OrderBy(s => s.Surname);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Programist>.CreateAsync(programist.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Programists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programist = await _context.Programists
                .Include(s => s.Managers)
                     .ThenInclude(e => e.Proekt)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            
        
            if (programist == null)
            {
                return NotFound();
            }

            return View(programist);
        }

        // GET: Programists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Programists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname,Email")] Programist programist)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    _context.Add(programist);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(programist);
        }

        // GET: Programists/Edit/5
       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var programist = await _context.Programists.FindAsync(id);
            if (programist == null)
            {
                return NotFound();
            }
            return View(programist);
        }

        // POST: Programists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programist = await _context.Programists.FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Programist>(
                programist,
                 "",
                s => s.Name, s => s.Surname, s => s.Email))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(programist);
        }

        // GET: Programists/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programist = await _context.Programists
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programist == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(programist);
        }

        // POST: Programists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programist = await _context.Programists.FindAsync(id);
            if (programist == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Programists.Remove(programist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { Id = id, saveChangesError = true });
            }
        }

        private bool ProgramistExists(int id)
        {
            return _context.Programists.Any(e => e.Id == id);
        }
    }
}
