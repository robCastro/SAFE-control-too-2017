using System.Data.Entity;

namespace SistemaRiesgo.Models
{
    public class ContextoEmpresa : DbContext
    {
        public ContextoEmpresa() : base("robertoC")
        {
        }

        public DbSet<Administrador> administradores { get; set; }
        public DbSet<Departamento> departamentos { get; set; }
        public DbSet<Empresa> empresas { get; set; }
        public DbSet<Usuario> usuarios { get; set; }

    }
}