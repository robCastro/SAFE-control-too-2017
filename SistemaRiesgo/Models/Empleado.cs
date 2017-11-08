using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SistemaRiesgo.Models
{
    public class Empleado
    {
        [Key]
        public int codigo { get; set; }

        [Required, StringLength(50), Display(Name = "Nombre")]
        public string nombre { get; set; }



        public int? codDepartamento { get; set; }

        public int? codEmpresa { get; set; }

        public string  idUsuario { get; set; } //actuará como una semi-llave foranea
        // que se enlazará con el Email del Usuario almacenado en las tablas
        // del IdentityFramework

        public virtual Empresa empresa { get; set; }

        public virtual Departamento departamento { get; set; }
    }
}