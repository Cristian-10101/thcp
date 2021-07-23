using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace thcp.Models
{
    public class PerceptionType
    {
        [Key]

        public int PerceptionTypeId { get; set; }

        [StringLength(30, ErrorMessage = "El Maximo es de 30 caracteres")]
        [Display(Name = "Tipo de Percepcion")]
        public string Description { get; set; }

        public IEnumerable<Perception>  Perceptions { get; set; }

    }
}
