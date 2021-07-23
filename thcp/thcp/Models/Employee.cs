using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace thcp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [StringLength(30, ErrorMessage = "No debe de tener mas de 30 Carateres.")]
        [Display(Name = "Nombres")]
        [MinLength(2, ErrorMessage = "Debe de tener mas de dos caracteres.")]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage = "No debe de tener mas de 30 Carateres.")]
        [Display(Name = "Apellidos")]
        [MinLength(2, ErrorMessage = "Debe de tener mas de dos caracteres.")]
        public string LastName { get; set; }

        [StringLength(30, ErrorMessage = "No debe de tener mas de 30 Carateres.")]
        [Display(Name = "Identidad")]
        [MinLength(2, ErrorMessage = "Debe de tener mas de dos caracteres.")]
        public string Indentity { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime BirthDay { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString ="{0:C0}")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Salario")]
        public Decimal Salary { get; set; }

        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position Position { get; set; }


    }
}

