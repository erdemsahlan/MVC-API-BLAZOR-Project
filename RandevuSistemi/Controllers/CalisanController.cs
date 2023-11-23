using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Data;
using Randevuobject;
using Microsoft.AspNetCore.Authorization;

namespace RandevuSistemi.Controllers
{
    [Authorize(Roles = "SistemAdmin, Kuaför")]
    public class CalisanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalisanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Calisan
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Calisanlar.Include(c => c.Plan);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Calisan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calisanlar == null)
            {
                return NotFound();
            }

            var calisan = await _context.Calisanlar
                .Include(c => c.Plan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calisan == null)
            {
                return NotFound();
            }

            return View(calisan);
        }

        // GET: Calisan/Create
        public IActionResult Create()
        {
            ViewData["CalismaPlaniId"] = new SelectList(_context.CalismaPlanlari, "Id", "PlanAdi");
            ViewData["KuaforId"] = new SelectList(_context.Kuaforler, "Id", "Adi");
            return View();
        }

        // POST: Calisan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Soyadi,IsYetkili,Aciklama,CalismaPlaniId,KuaforId")] Calisan calisan)
        {

            _context.Add(calisan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            ViewData["CalismaPlaniId"] = new SelectList(_context.CalismaPlanlari, "Id", "PlanAdi", calisan.CalismaPlaniId);
            ViewData["KuaforId"] = new SelectList(_context.Kuaforler, "Id", "Adi", calisan.KuaforId);
            return View(calisan);
        }

        // GET: Calisan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Calisanlar == null)
            {
                return NotFound();
            }

            var calisan = await _context.Calisanlar.FindAsync(id);
            if (calisan == null)
            {
                return NotFound();
            }
            ViewData["CalismaPlaniId"] = new SelectList(_context.CalismaPlanlari, "Id", "Aciklama", calisan.CalismaPlaniId);
            return View(calisan);
        }

        // POST: Calisan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Soyadi,IsYetkili,Aciklama,CalismaPlaniId")] Calisan calisan)
        {
            if (id != calisan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calisan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalisanExists(calisan.Id))
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
            ViewData["CalismaPlaniId"] = new SelectList(_context.CalismaPlanlari, "Id", "Aciklama", calisan.CalismaPlaniId);
            return View(calisan);
        }

        // GET: Calisan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Calisanlar == null)
            {
                return NotFound();
            }

            var calisan = await _context.Calisanlar
                .Include(c => c.Plan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calisan == null)
            {
                return NotFound();
            }

            return View(calisan);
        }

        // POST: Calisan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calisanlar == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Calisanlar'  is null.");
            }
            var calisan = await _context.Calisanlar.FindAsync(id);
            if (calisan != null)
            {
                _context.Calisanlar.Remove(calisan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalisanExists(int id)
        {
            return (_context.Calisanlar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
