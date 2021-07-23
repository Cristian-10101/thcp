using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using thcp.Models;

namespace thcp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<DeductionType> DeductionTypes { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
        public DbSet<PerceptionType> PerceptionTypes { get; set; }
        public DbSet<Perception> Perceptions { get; set; }
    }
}
