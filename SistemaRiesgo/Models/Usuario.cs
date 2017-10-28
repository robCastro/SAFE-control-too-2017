using System.ComponentModel.DataAnnotations;

namespace SistemaRiesgo.Models
{
    public class Usuario
    {
        [Key, Display(Name = "Usuario")]
        public string usuario{get; set;}

        [Required, StringLength(40), Display(Name = "Contraseña")]
        public string contraseña{get; set;}

    }
}