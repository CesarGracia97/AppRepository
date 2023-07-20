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
    public class AppsUserSchemeAppsController : Controller
    {
        private readonly AprovgrupotvContext _context;

        public AppsUserSchemeAppsController(AprovgrupotvContext context)
        {
            _context = context;
        }

        // GET: AppsUserSchemeApps
        public async Task<IActionResult> Index()
        {
              return _context.AppsUserSchemeApps != null ? 
                          View(await _context.AppsUserSchemeApps.ToListAsync()) :
                          Problem("Entity set 'AprovgrupotvContext.AppsUserSchemeApps'  is null.");
        }

        // GET: AppsUserSchemeApps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AppsUserSchemeApps == null)
            {
                return NotFound();
            }

            var appsUserSchemeApp = await _context.AppsUserSchemeApps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appsUserSchemeApp == null)
            {
                return NotFound();
            }

            return View(appsUserSchemeApp);
        }

        // GET: AppsUserSchemeApps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppsUserSchemeApps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAppsSchemeApps,IdAppsUser")] AppsUserSchemeApp appsUserSchemeApp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appsUserSchemeApp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appsUserSchemeApp);
        }

        // GET: AppsUserSchemeApps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AppsUserSchemeApps == null)
            {
                return NotFound();
            }

            var appsUserSchemeApp = await _context.AppsUserSchemeApps.FindAsync(id);
            if (appsUserSchemeApp == null)
            {
                return NotFound();
            }
            return View(appsUserSchemeApp);
        }

        // POST: AppsUserSchemeApps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAppsSchemeApps,IdAppsUser")] AppsUserSchemeApp appsUserSchemeApp)
        {
            if (id != appsUserSchemeApp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appsUserSchemeApp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppsUserSchemeAppExists(appsUserSchemeApp.Id))
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
            return View(appsUserSchemeApp);
        }

        // GET: AppsUserSchemeApps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AppsUserSchemeApps == null)
            {
                return NotFound();
            }

            var appsUserSchemeApp = await _context.AppsUserSchemeApps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appsUserSchemeApp == null)
            {
                return NotFound();
            }

            return View(appsUserSchemeApp);
        }

        // POST: AppsUserSchemeApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AppsUserSchemeApps == null)
            {
                return Problem("Entity set 'AprovgrupotvContext.AppsUserSchemeApps'  is null.");
            }
            var appsUserSchemeApp = await _context.AppsUserSchemeApps.FindAsync(id);
            if (appsUserSchemeApp != null)
            {
                _context.AppsUserSchemeApps.Remove(appsUserSchemeApp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppsUserSchemeAppExists(int id)
        {
          return (_context.AppsUserSchemeApps?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
