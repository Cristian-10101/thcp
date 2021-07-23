using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace thcp.Models
{
    public class Measure
    {

        [Key]

        public int MeasureId { get; set; }

        [StringLength(30, ErrorMessage ="El Maximo es de 30 caracteres")]
        [Display(Name ="Medida")]
        public string Description { get; set; }

        [StringLength(5, ErrorMessage = "El Maximo es de 5 caracteres")]
        [Display(Name = "Sombolo")]
        public string Symbol { get; set; }

        public IEnumerable<Deduction> Deductions { get; set; }

        public IEnumerable<Perception> Perceptions { get; set; }
    }
}
