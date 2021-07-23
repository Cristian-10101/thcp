using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thcp.Data;
using thcp.Models;

namespace thcp.Controllers
{
    public class DeductionTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeductionTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeductionTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DeductionTypes.ToListAsync());
        }

        // GET: DeductionTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deductionType = await _context.DeductionTypes
                .FirstOrDefaultAsync(m => m.DeductionTypeId == id);
            if (deductionType == null)
            {
                return NotFound();
            }

            return View(deductionType);
        }

        // GET: DeductionTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DeductionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeductionTypeId,Description")] DeductionType deductionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deductionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deductionType);
        }

        // GET: DeductionTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deductionType = await _context.DeductionTypes.FindAsync(id);
            if (deductionType == null)
            {
                return NotFound();
            }
            return View(deductionType);
        }

        // POST: DeductionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeductionTypeId,Description")] DeductionType deductionType)
        {
            if (id != deductionType.DeductionTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deductionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeductionTypeExists(deductionType.DeductionTypeId))
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
            return View(deductionType);
        }

        // GET: DeductionTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deductionType = await _context.DeductionTypes
                .FirstOrDefaultAsync(m => m.DeductionTypeId == id);
            if (deductionType == null)
            {
                return NotFound();
            }

            return View(deductionType);
        }

        // POST: DeductionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deductionType = await _context.DeductionTypes.FindAsync(id);
            _context.DeductionTypes.Remove(deductionType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeductionTypeExists(int id)
        {
            return _context.DeductionTypes.Any(e => e.DeductionTypeId == id);
        }
    }
}
