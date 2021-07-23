using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace thcp.Models
{
    public class DeductionType
    {
        [Key]

        public int DeductionTypeId { get; set; }

        [StringLength(30, ErrorMessage = "El Maximo es de 30 caracteres")]
        [Display(Name = "Tipo de Deduccion")]
        public string Description { get; set; }

        public IEnumerable<Deduction> Deductions { get; set; }

    }
}
