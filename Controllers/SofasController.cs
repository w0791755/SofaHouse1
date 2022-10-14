using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SofaHouse.Data;
using SofaHouse.Models;

namespace SofaHouse.Controllers
{
    public class SofasController : Controller
    {
        private readonly SofaHouseContext _context;

        public SofasController(SofaHouseContext context)
        {
            _context = context;
        }

        // GET: Sofas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sofa.ToListAsync());
        }

        // GET: Sofas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofa = await _context.Sofa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sofa == null)
            {
                return NotFound();
            }

            return View(sofa);
        }

        // GET: Sofas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sofas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,type,material,size,theme,availability,price,ReleaseDate,Rating")] Sofa sofa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sofa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sofa);
        }

        // GET: Sofas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofa = await _context.Sofa.FindAsync(id);
            if (sofa == null)
            {
                return NotFound();
            }
            return View(sofa);
        }

        // POST: Sofas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,type,material,size,theme,availability,price,ReleaseDate,Rating")] Sofa sofa)
        {
            if (id != sofa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sofa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SofaExists(sofa.Id))
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
            return View(sofa);
        }

        // GET: Sofas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sofa = await _context.Sofa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sofa == null)
            {
                return NotFound();
            }

            return View(sofa);
        }

        // POST: Sofas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sofa = await _context.Sofa.FindAsync(id);
            _context.Sofa.Remove(sofa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SofaExists(int id)
        {
            return _context.Sofa.Any(e => e.Id == id);
        }
    }
}
