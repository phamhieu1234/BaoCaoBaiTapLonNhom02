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
    public class NhomController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NhomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nhom
        public async Task<IActionResult> Index()
        {
              return _context.Nhom != null ? 
                          View(await _context.Nhom.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Nhom'  is null.");
        }

        // GET: Nhom/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhom == null)
            {
                return NotFound();
            }

            var nhom = await _context.Nhom
                .FirstOrDefaultAsync(m => m.MaNhom == id);
            if (nhom == null)
            {
                return NotFound();
            }

            return View(nhom);
        }

        // GET: Nhom/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nhom/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNhom,TenNhom")] Nhom nhom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhom);
        }

        // GET: Nhom/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhom == null)
            {
                return NotFound();
            }

            var nhom = await _context.Nhom.FindAsync(id);
            if (nhom == null)
            {
                return NotFound();
            }
            return View(nhom);
        }

        // POST: Nhom/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNhom,TenNhom")] Nhom nhom)
        {
            if (id != nhom.MaNhom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhomExists(nhom.MaNhom))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["SuccessMessage"] = "Nhom" + nhom  + "Edit Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(nhom);
        }

        // GET: Nhom/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nhom == null)
            {
                return NotFound();
            }

            var nhom = await _context.Nhom
                .FirstOrDefaultAsync(m => m.MaNhom == id);
            if (nhom == null)
            {
                return NotFound();
            }

            return View(nhom);
        }

        // POST: Nhom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nhom == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Nhom'  is null.");
            }
            var nhom = await _context.Nhom.FindAsync(id);
            if (nhom != null)
            {
                _context.Nhom.Remove(nhom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhomExists(string id)
        {
          return (_context.Nhom?.Any(e => e.MaNhom == id)).GetValueOrDefault();
        }
    }
}
