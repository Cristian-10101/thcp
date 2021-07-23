using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace thcp.Models
{
    public class Deduction
    {
        [Key]

        public int DeductionId { get; set; }

        [StringLength(30, ErrorMessage = "El Maximo es de 30 caracteres")]
        [Display(Name = "Deduccion")]
        public string Description { get; set; }

        [Display(Name = "Valor")]
        [Column(TypeName ="decimal(12,2)")]
        public Decimal Value { get; set; }

        public int DeductionTypeId { get; set; }

        [ForeignKey("DeductionTypeId")]
        public DeductionType DeductionType { get; set; }

        public int MeasureId { get; set; }

        [ForeignKey("MeasureId")]
        public Measure Measure { get; set; }

    }
}
