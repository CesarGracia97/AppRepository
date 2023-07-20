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
    public class AppsUsersController : Controller
    {
        private readonly AprovgrupotvContext _context;

        public AppsUsersController(AprovgrupotvContext context)
        {
            _context = context;
        }

        // GET: AppsUsers
        public async Task<IActionResult> Index()
        {
              return _context.AppsUsers != null ? 
                          View(await _context.AppsUsers.ToListAsync()) :
                          Problem("Entity set 'AprovgrupotvContext.AppsUsers'  is null.");
        }

        // GET: AppsUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AppsUsers == null)
            {
                return NotFound();
            }

            var appsUser = await _context.AppsUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appsUser == null)
            {
                return NotFound();
            }

            return View(appsUser);
        }

        // GET: AppsUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppsUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AppsUser1,AppsFullNames,AppsDescritionUser")] AppsUser appsUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appsUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appsUser);
        }

        // GET: AppsUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AppsUsers == null)
            {
                return NotFound();
            }

            var appsUser = await _context.AppsUsers.FindAsync(id);
            if (appsUser == null)
            {
                return NotFound();
            }
            return View(appsUser);
        }

        // POST: AppsUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AppsUser1,AppsFullNames,AppsDescritionUser")] AppsUser appsUser)
        {
            if (id != appsUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appsUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppsUserExists(appsUser.Id))
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
            return View(appsUser);
        }

        // GET: AppsUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AppsUsers == null)
            {
                return NotFound();
            }

            var appsUser = await _context.AppsUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appsUser == null)
            {
                return NotFound();
            }

            return View(appsUser);
        }

        // POST: AppsUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AppsUsers == null)
            {
                return Problem("Entity set 'AprovgrupotvContext.AppsUsers'  is null.");
            }
            var appsUser = await _context.AppsUsers.FindAsync(id);
            if (appsUser != null)
            {
                _context.AppsUsers.Remove(appsUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppsUserExists(int id)
        {
          return (_context.AppsUsers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
