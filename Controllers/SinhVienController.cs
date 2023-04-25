using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaoCaoBaiTapLonNhom02.Models;
using BaoCaoBaiTapLonNhom02.Data;
using BaoCaoBaiTapLonNhom02.Models.Process;

namespace BaoCaoBaiTapLonNhom02.Controllers
{
    public class SinhVienController : Controller
    {
        StringProcess strPro = new StringProcess();
        private readonly ApplicationDbContext _context;

        public SinhVienController(ApplicationDbContext context)
        {
            _context = context;
        }

    public async Task<IActionResult> Index( string Nhom, string Cathi, string Ten)
{
    var applicationDbContext = _context.SinhVien.Include(s => s.Nhom).Include(s => s.Cathi).AsQueryable();
    if (!string.IsNullOrEmpty(Ten))
    {
        applicationDbContext = applicationDbContext.Where(s => s.TenSV.Contains(Ten));
    }
    if (!string.IsNullOrEmpty(Cathi))
    {
        applicationDbContext = applicationDbContext.Where(s => s.Cathi.TenCathi.Contains(Cathi));
    }
    if (!string.IsNullOrEmpty(Nhom))
    {
        applicationDbContext = applicationDbContext.Where(s => s.Nhom.TenNhom.Contains(Nhom));
    }
    
     
    return View(await applicationDbContext.ToListAsync());
}

        // GET: SinhVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SinhVien == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .Include(s => s.Nhom)
                .FirstOrDefaultAsync(m => m.MaSV == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: SinhVien/Create
        public IActionResult Create()
        {
             var newMaSV = "";
            if (_context.SinhVien.Count() == 0)
            {
                newMaSV = "CNTT1921001";
            }
            else
            {
                var id = _context.SinhVien.OrderByDescending(m =>m.MaSV).First().MaSV;
                newMaSV = strPro.AutoGenerateKey(id);
            }
            ViewBag.SinhVien = newMaSV;
            ViewData["MaNhom"] = new SelectList(_context.Set<Nhom>(), "MaNhom", "MaNhom");
            ViewData["MaCathi"] = new SelectList(_context.Set<Cathi>(), "MaCathi", "MaCathi");

            return View();
        }

        // POST: SinhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSV,TenSV,MaNhom,MaCathi")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNhom"] = new SelectList(_context.Set<Nhom>(), "MaNhom", "MaNhom", sinhVien.MaNhom);
            ViewData["MaCathi"] = new SelectList(_context.Set<Cathi>(), "MaCathi", "MaCathi", sinhVien.MaCathi);
            return View(sinhVien);
            
        }

        // GET: SinhVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.SinhVien == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            ViewData["MaNhom"] = new SelectList(_context.Set<Nhom>(), "MaNhom", "MaNhom", sinhVien.MaNhom);
            ViewData["MaCathi"] = new SelectList(_context.Set<Cathi>(), "MaCathi", "MaCathi", sinhVien.MaCathi);
            return View(sinhVien);
        }

        // POST: SinhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSV,TenSV,MaNhom")] SinhVien sinhVien)
        {
            if (id != sinhVien.MaSV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.MaSV))
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
            ViewData["MaNhom"] = new SelectList(_context.Set<Nhom>(), "MaNhom", "MaNhom", sinhVien.MaNhom);
            ViewData["MaCathi"] = new SelectList(_context.Set<Cathi>(), "MaCathi", "MaCathi", sinhVien.MaCathi);
            return View(sinhVien);
        }

        // GET: SinhVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SinhVien == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .Include(s => s.Nhom)
                .FirstOrDefaultAsync(m => m.MaSV == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SinhVien == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SinhVien'  is null.");
            }
            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SinhVien.Remove(sinhVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
          return (_context.SinhVien?.Any(e => e.MaSV == id)).GetValueOrDefault();
        }
    }
}
