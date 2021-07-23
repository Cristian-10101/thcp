using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace thcp.Models
{
    public class Departament
    {
        [Key]
        public int DepartamentId { get; set; }
        [Required(ErrorMessage ="El Nombre es obligatorio")]
        [Display(Name = "Departamento")]
        [StringLength(70, ErrorMessage = "No debe de tener mas de 70 Carateres.")]
        [MinLength(3, ErrorMessage = "Debe de tener mas de tres caracteres.")]
        public string DepartamentName { get; set; }

        public IEnumerable<Position> Employees { get; set; }
    }
}
