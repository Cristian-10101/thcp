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
    public class Perceptions1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Perceptions1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Perceptions1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Perceptions.Include(p => p.Measure).Include(p => p.PerceptionType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Perceptions1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perception = await _context.Perceptions
                .Include(p => p.Measure)
                .Include(p => p.PerceptionType)
                .FirstOrDefaultAsync(m => m.PerceptionId == id);
            if (perception == null)
            {
                return NotFound();
            }

            return View(perception);
        }

        // GET: Perceptions1/Create
        public IActionResult Create()
        {
            ViewData["MeasureId"] = new SelectList(_context.Measures, "MeasureId", "MeasureId");
            ViewData["PerceptionTypeId"] = new SelectList(_context.PerceptionTypes, "PerceptionTypeId", "PerceptionTypeId");
            return View();
        }

        // POST: Perceptions1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerceptionId,Description,Value,PerceptionTypeId,MeasureId")] Perception perception)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perception);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MeasureId"] = new SelectList(_context.Measures, "MeasureId", "Description", perception.MeasureId);
            ViewData["PerceptionTypeId"] = new SelectList(_context.PerceptionTypes, "PerceptionTypeId", "Description", perception.PerceptionTypeId);
            return View(perception);
        }

        // GET: Perceptions1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perception = await _context.Perceptions.FindAsync(id);
            if (perception == null)
            {
                return NotFound();
            }
            ViewData["MeasureId"] = new SelectList(_context.Measures, "MeasureId", "Description", perception.MeasureId);
            ViewData["PerceptionTypeId"] = new SelectList(_context.PerceptionTypes, "PerceptionTypeId", "Description", perception.PerceptionTypeId);
            return View(perception);
        }

        // POST: Perceptions1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PerceptionId,Description,Value,PerceptionTypeId,MeasureId")] Perception perception)
        {
            if (id != perception.PerceptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perception);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerceptionExists(perception.PerceptionId))
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
            ViewData["MeasureId"] = new SelectList(_context.Measures, "MeasureId", "Description", perception.MeasureId);
            ViewData["PerceptionTypeId"] = new SelectList(_context.PerceptionTypes, "PerceptionTypeId", "Description", perception.PerceptionTypeId);
            return View(perception);
        }

        // GET: Perceptions1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perception = await _context.Perceptions
                .Include(p => p.Measure)
                .Include(p => p.PerceptionType)
                .FirstOrDefaultAsync(m => m.PerceptionId == id);
            if (perception == null)
            {
                return NotFound();
            }

            return View(perception);
        }

        // POST: Perceptions1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perception = await _context.Perceptions.FindAsync(id);
            _context.Perceptions.Remove(perception);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerceptionExists(int id)
        {
            return _context.Perceptions.Any(e => e.PerceptionId == id);
        }
    }
}
