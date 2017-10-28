using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SistemaRiesgo.Models
{
    public class Empresa
    {
        [Key]
        public int codigo {get; set;} 

        [Required, StringLength(100), Display(Name = "Nombre de Empresa")]
        public string nombre{get; set;}

        [StringLength(200), Display(Name = "Objetivos"), DataType(DataType.MultilineText)]
        public string objetivos{get; set;}

        [StringLength(200), Display(Name = "Alcance"), DataType(DataType.MultilineText)]
        public string alcance{get; set;}

        public string idAdmin { get; set; }


        public virtual ICollection<Empleado> empleadosGlobales { get; set; } //listado de empleados Globales de esta empresa

        public virtual ICollection<Departamento> departamentos{get; set;}
    }
}