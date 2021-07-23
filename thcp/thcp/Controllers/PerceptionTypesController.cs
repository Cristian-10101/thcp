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
    public class PerceptionTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerceptionTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PerceptionTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PerceptionTypes.ToListAsync());
        }

        // GET: PerceptionTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perceptionType = await _context.PerceptionTypes
                .FirstOrDefaultAsync(m => m.PerceptionTypeId == id);
            if (perceptionType == null)
            {
                return NotFound();
            }

            return View(perceptionType);
        }

        // GET: PerceptionTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PerceptionTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerceptionTypeId,Description")] PerceptionType perceptionType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perceptionType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perceptionType);
        }

        // GET: PerceptionTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perceptionType = await _context.PerceptionTypes.FindAsync(id);
            if (perceptionType == null)
            {
                return NotFound();
            }
            return View(perceptionType);
        }

        // POST: PerceptionTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PerceptionTypeId,Description")] PerceptionType perceptionType)
        {
            if (id != perceptionType.PerceptionTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perceptionType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerceptionTypeExists(perceptionType.PerceptionTypeId))
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
            return View(perceptionType);
        }

        // GET: PerceptionTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perceptionType = await _context.PerceptionTypes
                .FirstOrDefaultAsync(m => m.PerceptionTypeId == id);
            if (perceptionType == null)
            {
                return NotFound();
            }

            return View(perceptionType);
        }

        // POST: PerceptionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perceptionType = await _context.PerceptionTypes.FindAsync(id);
            _context.PerceptionTypes.Remove(perceptionType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerceptionTypeExists(int id)
        {
            return _context.PerceptionTypes.Any(e => e.PerceptionTypeId == id);
        }
    }
}
