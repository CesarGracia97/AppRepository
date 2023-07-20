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
    public class AppsSchemeAppsController : Controller
    {
        private readonly AprovgrupotvContext _context;

        public AppsSchemeAppsController(AprovgrupotvContext context)
        {
            _context = context;
        }

        // GET: AppsSchemeApps
        public async Task<IActionResult> Index()
        {
              return _context.AppsSchemeApps != null ? 
                          View(await _context.AppsSchemeApps.ToListAsync()) :
                          Problem("Entity set 'AprovgrupotvContext.AppsSchemeApps'  is null.");
        }

        // GET: AppsSchemeApps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AppsSchemeApps == null)
            {
                return NotFound();
            }

            var appsSchemeApp = await _context.AppsSchemeApps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appsSchemeApp == null)
            {
                return NotFound();
            }

            return View(appsSchemeApp);
        }

        // GET: AppsSchemeApps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppsSchemeApps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAppsScheme,IdAppsApps")] AppsSchemeApp appsSchemeApp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appsSchemeApp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appsSchemeApp);
        }

        // GET: AppsSchemeApps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AppsSchemeApps == null)
            {
                return NotFound();
            }

            var appsSchemeApp = await _context.AppsSchemeApps.FindAsync(id);
            if (appsSchemeApp == null)
            {
                return NotFound();
            }
            return View(appsSchemeApp);
        }

        // POST: AppsSchemeApps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAppsScheme,IdAppsApps")] AppsSchemeApp appsSchemeApp)
        {
            if (id != appsSchemeApp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appsSchemeApp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppsSchemeAppExists(appsSchemeApp.Id))
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
            return View(appsSchemeApp);
        }

        // GET: AppsSchemeApps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AppsSchemeApps == null)
            {
                return NotFound();
            }

            var appsSchemeApp = await _context.AppsSchemeApps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appsSchemeApp == null)
            {
                return NotFound();
            }

            return View(appsSchemeApp);
        }

        // POST: AppsSchemeApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AppsSchemeApps == null)
            {
                return Problem("Entity set 'AprovgrupotvContext.AppsSchemeApps'  is null.");
            }
            var appsSchemeApp = await _context.AppsSchemeApps.FindAsync(id);
            if (appsSchemeApp != null)
            {
                _context.AppsSchemeApps.Remove(appsSchemeApp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppsSchemeAppExists(int id)
        {
          return (_context.AppsSchemeApps?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
