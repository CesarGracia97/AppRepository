using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class AppsApplicationsController : Controller
    {
        private readonly AprovgrupotvContext _context;

        public AppsApplicationsController(AprovgrupotvContext context)
        {
            _context = context;
        }

        // GET: AppsApplications
        public async Task<IActionResult> Index()
        {
              return _context.AppsApplications != null ? 
                          View(await _context.AppsApplications.ToListAsync()) :
                          Problem("Entity set 'AprovgrupotvContext.AppsApplications'  is null.");
        }

        // GET: AppsApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AppsApplications == null)
            {
                return NotFound();
            }

            var appsApplication = await _context.AppsApplications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appsApplication == null)
            {
                return NotFound();
            }

            return View(appsApplication);
        }

        // GET: AppsApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppsApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameApplication,DescriptionApplication")] AppsApplication appsApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appsApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appsApplication);
        }

        // GET: AppsApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AppsApplications == null)
            {
                return NotFound();
            }

            var appsApplication = await _context.AppsApplications.FindAsync(id);
            if (appsApplication == null)
            {
                return NotFound();
            }
            return View(appsApplication);
        }

        // POST: AppsApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameApplication,DescriptionApplication")] AppsApplication appsApplication)
        {
            if (id != appsApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appsApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppsApplicationExists(appsApplication.Id))
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
            return View(appsApplication);
        }

        // GET: AppsApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AppsApplications == null)
            {
                return NotFound();
            }

            var appsApplication = await _context.AppsApplications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appsApplication == null)
            {
                return NotFound();
            }

            return View(appsApplication);
        }

        // POST: AppsApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AppsApplications == null)
            {
                return Problem("Entity set 'AprovgrupotvContext.AppsApplications'  is null.");
            }
            var appsApplication = await _context.AppsApplications.FindAsync(id);
            if (appsApplication != null)
            {
                _context.AppsApplications.Remove(appsApplication);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppsApplicationExists(int id)
        {
          return (_context.AppsApplications?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
