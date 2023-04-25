using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaoCaoBaiTapLonNhom01.Models;
using BaoCaoBaiTapLonNhom02.Data;

namespace BaoCaoBaiTapLonNhom02.Controllers
{
    public class DangNhapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DangNhapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DangNhap
        public async Task<IActionResult> Index()
        {
              return _context.DangNhap != null ? 
                          View(await _context.DangNhap.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DangNhap'  is null.");
        }

        // GET: DangNhap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DangNhap == null)
            {
                return NotFound();
            }

            var dangNhap = await _context.DangNhap
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (dangNhap == null)
            {
                return NotFound();
            }

            return View(dangNhap);
        }

        // GET: DangNhap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DangNhap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,username,Password")] DangNhap dangNhap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangNhap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dangNhap);
        }

        // GET: DangNhap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DangNhap == null)
            {
                return NotFound();
            }

            var dangNhap = await _context.DangNhap.FindAsync(id);
            if (dangNhap == null)
            {
                return NotFound();
            }
            return View(dangNhap);
        }

        // POST: DangNhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,username,Password")] DangNhap dangNhap)
        {
            if (id != dangNhap.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangNhap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangNhapExists(dangNhap.UserID))
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
            return View(dangNhap);
        }

        // GET: DangNhap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DangNhap == null)
            {
                return NotFound();
            }

            var dangNhap = await _context.DangNhap
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (dangNhap == null)
            {
                return NotFound();
            }

            return View(dangNhap);
        }

        // POST: DangNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DangNhap == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DangNhap'  is null.");
            }
            var dangNhap = await _context.DangNhap.FindAsync(id);
            if (dangNhap != null)
            {
                _context.DangNhap.Remove(dangNhap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangNhapExists(int id)
        {
          return (_context.DangNhap?.Any(e => e.UserID == id)).GetValueOrDefault();
        }
      public IActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(DangNhap model)
       {
            if(ModelState.IsValid)
            {
                var User = from m in _context.DangNhap select m;
                User = User.Where(s =>s.username.Contains(model.username));
                if(User.Count() !=0)
                {
                    if (User.First().Password == model.Password)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            else
                 {
                         TempData["Error"] = "Bạn cần nhập lại mật khẩu";
                }   
             }
        return RedirectToAction("DangNhap");
        }
    }
}
