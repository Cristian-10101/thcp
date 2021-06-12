using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thcp.Data;

namespace thcp.Controllers
{
    public class DepartamentsController : Controller
    {
        private readonly ApplicationDbContext db;

        public DepartamentsController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Departaments.ToListAsync());
        }

        //Crear por medio de vista
        public IActionResult Create()
        {
            return View();
        }
    }
}
