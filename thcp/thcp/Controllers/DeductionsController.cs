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
    public class DeductionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeductionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Deductions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Deductions.Include(d => d.DeductionType).Include(d => d.Measure);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Deductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deduction = await _context.Deductions
                .Include(d => d.DeductionType)
                .Include(d => d.Measure)
                .FirstOrDefaultAsync(m => m.DeductionId == id);
            if (deduction == null)
            {
                return NotFound();
            }

            return View(deduction);
        }

        // GET: Deductions/Create
        public IActionResult Create()
        {
            ViewData["DeductionTypeId"] = new SelectList(_context.DeductionTypes, "DeductionTypeId", "Description");
            ViewData["MeasureId"] = new SelectList(_context.Measures, "MeasureId", "Description");
            return View();
        }

        // POST: Deductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeductionId,Description,Value,DeductionTypeId,MeasureId")] Deduction deduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeductionTypeId"] = new SelectList(_context.DeductionTypes, "DeductionTypeId", "Description", deduction.DeductionTypeId);
            ViewData["MeasureId"] = new SelectList(_context.Measures, "MeasureId", "Description", deduction.MeasureId);
            return View(deduction);
        }

        // GET: Deductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deduction = await _context.Deductions.FindAsync(id);
            if (deduction == null)
            {
                return NotFound();
            }
            ViewData["DeductionTypeId"] = new SelectList(_context.DeductionTypes, "DeductionTypeId", "Description", deduction.DeductionTypeId);
            ViewData["MeasureId"] = new SelectList(_context.Measures, "MeasureId", "Description", deduction.MeasureId);
            return View(deduction);
        }

        // POST: Deductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeductionId,Description,Value,DeductionTypeId,MeasureId")] Deduction deduction)
        {
            if (id != deduction.DeductionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeductionExists(deduction.DeductionId))
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
            ViewData["DeductionTypeId"] = new SelectList(_context.DeductionTypes, "DeductionTypeId", "Description", deduction.DeductionTypeId);
            ViewData["MeasureId"] = new SelectList(_context.Measures, "MeasureId", "Description", deduction.MeasureId);
            return View(deduction);
        }

        // GET: Deductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deduction = await _context.Deductions
                .Include(d => d.DeductionType)
                .Include(d => d.Measure)
                .FirstOrDefaultAsync(m => m.DeductionId == id);
            if (deduction == null)
            {
                return NotFound();
            }

            return View(deduction);
        }

        // POST: Deductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deduction = await _context.Deductions.FindAsync(id);
            _context.Deductions.Remove(deduction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeductionExists(int id)
        {
            return _context.Deductions.Any(e => e.DeductionId == id);
        }
    }
}
