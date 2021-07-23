using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thcp.Common;
using thcp.Data;
using thcp.Models;

namespace thcp.Controllers
{
    public class DepartamentsController : Controller
    {
        private readonly int RecordsPerPage = 10;

        private Pagination<Departament> PaginationDepartaments;

        private readonly ApplicationDbContext db;

        public DepartamentsController(ApplicationDbContext db)
        {
            this.db = db;
        }

       /* [Route("/Departaments")]
        [Route("/Departaments/{search}")]
        [Route("/Departaments/{search}/{page}")]*/

        public async Task<IActionResult> Index(String search, int page = 1 )
        {
            int totalRecords = 0;
            if (search == null)
            {
                search = "";
            }
            //Obtener los registros totales 
            totalRecords = await db.Departaments.CountAsync(
                    d => d.DepartamentName.Contains(search)
                );

            //Obtener datos
            var departaments = await db.Departaments
                .Where(d => d.DepartamentName.Contains(search)).ToListAsync();

            var departamentsResult = departaments.OrderBy(x => x.DepartamentName)
                .Skip((page - 1)*RecordsPerPage)
                .Take(RecordsPerPage);
            //Obtenerel total de paginas
            var totalPage = (int)Math.Ceiling((double)totalRecords / RecordsPerPage);

            //Iniciar la clase de paginacion
            PaginationDepartaments = new Pagination<Departament>()
            {
                RecordsPerPage = this.RecordsPerPage,
                TotalRecords = totalRecords,
                TotalPage = totalPage,
                CurrentPage = page,
                Search = search,
                Result = departamentsResult
            };

            return View(PaginationDepartaments);

        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var depart = await db.Departaments.FirstOrDefaultAsync(d => d.DepartamentId == id);
            if (depart == null)
            {
                return NotFound();
            }
            return View(depart);
        }

        //Crear por medio de vista
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departament departament)
        {
            if (ModelState.IsValid)
            {
                db.Add(departament);

                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            return View(departament);

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var depart = await db.Departaments.FindAsync(id);

            if (depart == null)
            {
                return NotFound();
            }
            return View(depart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Departament depart) 
        {
            if (id != depart.DepartamentId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(depart);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                    
                }

                return RedirectToAction(nameof(Index));
            }
            return View(depart);
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var depart = await db.Departaments.FirstOrDefaultAsync(d => d.DepartamentId == id);
            if (depart == null)
            {
                return NotFound();
            }
            return View(depart);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var depart = await db.Departaments.FindAsync(id);
            db.Departaments.Remove(depart);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
