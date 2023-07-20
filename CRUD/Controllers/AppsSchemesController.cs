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
    public class AppsSchemesController : Controller
    {
        private readonly AprovgrupotvContext _context;

        public AppsSchemesController(AprovgrupotvContext context)
        {
            _context = context;
        }

        // GET: AppsSchemes
        public async Task<IActionResult> Index()
        {
              return _context.AppsSchemes != null ? 
                          View(await _context.AppsSchemes.ToListAsync()) :
                          Problem("Entity set 'AprovgrupotvContext.AppsSchemes'  is null.");
        }

        // GET: AppsSchemes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AppsSchemes == null)
            {
                return NotFound();
            }

            var appsScheme = await _context.AppsSchemes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appsScheme == null)
            {
                return NotFound();
            }

            return View(appsScheme);
        }

        // GET: AppsSchemes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppsSchemes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DescriptionScheme,NameScheme")] AppsScheme appsScheme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appsScheme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appsScheme);
        }

        // GET: AppsSchemes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AppsSchemes == null)
            {
                return NotFound();
            }

            var appsScheme = await _context.AppsSchemes.FindAsync(id);
            if (appsScheme == null)
            {
                return NotFound();
            }
            return View(appsScheme);
        }

        // POST: AppsSchemes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescriptionScheme,NameScheme")] AppsScheme appsScheme)
        {
            if (id != appsScheme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appsScheme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppsSchemeExists(appsScheme.Id))
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
            return View(appsScheme);
        }

        // GET: AppsSchemes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AppsSchemes == null)
            {
                return NotFound();
            }

            var appsScheme = await _context.AppsSchemes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appsScheme == null)
            {
                return NotFound();
            }

            return View(appsScheme);
        }

        // POST: AppsSchemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AppsSchemes == null)
            {
                return Problem("Entity set 'AprovgrupotvContext.AppsSchemes'  is null.");
            }
            var appsScheme = await _context.AppsSchemes.FindAsync(id);
            if (appsScheme != null)
            {
                _context.AppsSchemes.Remove(appsScheme);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppsSchemeExists(int id)
        {
          return (_context.AppsSchemes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
