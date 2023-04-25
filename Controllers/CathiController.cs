using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaoCaoBaiTapLonNhom02.Models;
using BaoCaoBaiTapLonNhom02.Data;

namespace BaoCaoBaiTapLonNhom02.Controllers
{
    public class CathiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CathiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cathi
        public async Task<IActionResult> Index()
        {
              return _context.Cathi != null ? 
                          View(await _context.Cathi.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cathi'  is null.");
        }

        // GET: Cathi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Cathi == null)
            {
                return NotFound();
            }

            var cathi = await _context.Cathi
                .FirstOrDefaultAsync(m => m.MaCathi == id);
            if (cathi == null)
            {
                return NotFound();
            }

            return View(cathi);
        }

        // GET: Cathi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cathi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCathi,TenCathi")] Cathi cathi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cathi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cathi);
        }

        // GET: Cathi/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Cathi == null)
            {
                return NotFound();
            }

            var cathi = await _context.Cathi.FindAsync(id);
            if (cathi == null)
            {
                return NotFound();
            }
            return View(cathi);
        }

        // POST: Cathi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaCathi,TenCathi")] Cathi cathi)
        {
            if (id != cathi.MaCathi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cathi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CathiExists(cathi.MaCathi))
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
            return View(cathi);
        }

        // GET: Cathi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Cathi == null)
            {
                return NotFound();
            }

            var cathi = await _context.Cathi
                .FirstOrDefaultAsync(m => m.MaCathi == id);
            if (cathi == null)
            {
                return NotFound();
            }

            return View(cathi);
        }

        // POST: Cathi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Cathi == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cathi'  is null.");
            }
            var cathi = await _context.Cathi.FindAsync(id);
            if (cathi != null)
            {
                _context.Cathi.Remove(cathi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CathiExists(string id)
        {
          return (_context.Cathi?.Any(e => e.MaCathi == id)).GetValueOrDefault();
        }
    }
}
