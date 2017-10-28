using System.ComponentModel.DataAnnotations;

namespace SistemaRiesgo.Models
{
    public class Administrador
    {
        [Key]
        public string usuarioAdmin { get; set; }

        public int? codigoEmpresa { get; set; }
        
        
        public virtual Usuario usuario { get; set; }

        public virtual Empresa empresa { get; set; }
    }
}