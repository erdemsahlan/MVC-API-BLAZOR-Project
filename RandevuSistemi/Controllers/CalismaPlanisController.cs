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
    public class CalismaPlanisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalismaPlanisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CalismaPlanis
        public async Task<IActionResult> Index()
        {
              return _context.CalismaPlanlari != null ? 
                          View(await _context.CalismaPlanlari.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CalismaPlanlari'  is null.");
        }

        // GET: CalismaPlanis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CalismaPlanlari == null)
            {
                return NotFound();
            }

            var calismaPlani = await _context.CalismaPlanlari
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calismaPlani == null)
            {
                return NotFound();
            }

            return View(calismaPlani);
        }

        // GET: CalismaPlanis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CalismaPlanis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlanAdi,MusteriBasinaZaman,IsHahtasonuCalisma,MesaiBaslamaSaati,MesaiBitisSaati,Aciklama")] CalismaPlani calismaPlani)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calismaPlani);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calismaPlani);
        }

        // GET: CalismaPlanis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CalismaPlanlari == null)
            {
                return NotFound();
            }

            var calismaPlani = await _context.CalismaPlanlari.FindAsync(id);
            if (calismaPlani == null)
            {
                return NotFound();
            }
            return View(calismaPlani);
        }

        // POST: CalismaPlanis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlanAdi,MusteriBasinaZaman,IsHahtasonuCalisma,MesaiBaslamaSaati,MesaiBitisSaati,Aciklama")] CalismaPlani calismaPlani)
        {
            if (id != calismaPlani.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calismaPlani);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalismaPlaniExists(calismaPlani.Id))
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
            return View(calismaPlani);
        }

        // GET: CalismaPlanis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CalismaPlanlari == null)
            {
                return NotFound();
            }

            var calismaPlani = await _context.CalismaPlanlari
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calismaPlani == null)
            {
                return NotFound();
            }

            return View(calismaPlani);
        }

        // POST: CalismaPlanis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CalismaPlanlari == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CalismaPlanlari'  is null.");
            }
            var calismaPlani = await _context.CalismaPlanlari.FindAsync(id);
            if (calismaPlani != null)
            {
                _context.CalismaPlanlari.Remove(calismaPlani);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalismaPlaniExists(int id)
        {
          return (_context.CalismaPlanlari?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
