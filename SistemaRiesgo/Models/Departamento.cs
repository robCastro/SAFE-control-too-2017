using System.ComponentModel.DataAnnotations;


namespace SistemaRiesgo.Models
{
    public class Departamento
    {
        [Key, Display(Name="Codigo"), ScaffoldColumn(false) ]
        public int codigo { get; set; }

        [Required, StringLength(50), Display(Name = "Nombre")]
        public string nombre { get; set; }

        public int? codigoEmpresa { get; set; }

        public virtual Empresa empresa { get; set; }
    }
}