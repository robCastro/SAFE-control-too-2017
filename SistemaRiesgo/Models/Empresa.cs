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

        [StringLength(200), Display(Name = "Objetivos")]
        public string objetivos{get; set;}

        [StringLength(200), Display(Name = "Alcance")]
        public string alcance{get; set;}

        public string idAdmin { get; set; }
        

        public virtual ICollection<Departamento> departamentos{get; set;}
    }
}