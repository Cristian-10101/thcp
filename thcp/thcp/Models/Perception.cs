using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace thcp.Models
{
    public class Perception
    {
        [Key]

        public int PerceptionId { get; set; }

        [StringLength(30, ErrorMessage = "El Maximo es de 30 caracteres")]
        [Display(Name = "Percepcion")]
        public string Description { get; set; }


        [Display(Name = "Valor")]
        [Column(TypeName = "decimal(12,2)")]
        public Decimal Value { get; set; }
        public int PerceptionTypeId { get; set; } 

        [ForeignKey("PerceptionTypeId")]
        public PerceptionType PerceptionType { get; set; }

        public int MeasureId { get; set; }

        [ForeignKey("MeasureId")]
        public Measure Measure { get; set; }
    }
}
