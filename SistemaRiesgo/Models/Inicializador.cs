using System.Collections.Generic;
using System.Data.Entity;

namespace SistemaRiesgo.Models
{
    public class Inicializador : DropCreateDatabaseIfModelChanges<ContextoEmpresa>
    {

        private static List<Usuario> getUsuarios()
        {
            var usuarios = new List<Usuario>
            {
               
                new Usuario 
                {
                    usuario = "mim_1996",
                    contraseña = "contraseña"
                },
                new Usuario 
                {
                    usuario = "salvadorramos_2001",
                    contraseña = "contraseña"
                },
            };
            return usuarios;
        }

        private static List<Administrador> getAdministradores()
        {
            var administradores = new List<Administrador>
            {
                new Administrador
                {
                    usuarioAdmin = "mim_1996",
                    codigoEmpresa = 1,
                },
                new Administrador
                {
                    usuarioAdmin = "salvadorramos_2001",
                    codigoEmpresa = 2,
                },
            };
            return administradores;
        }

        private static List<Empresa> getEmpresas()
        {
            var empresas = new List<Empresa>
            {
                new Empresa
                {
                    codigo = 1,
                    nombre = "Empresa Ejemplo 1",
                    objetivos = "asdsdf",
                    alcance = "asdsd",
                },
                new Empresa
                {
                    codigo = 2,
                    nombre = "Empresa Ejemplo 2",
                    objetivos = "asdsdf",
                    alcance = "asdsd",
                },
            };
            return empresas;
        }

        private static List<Departamento> getDepartamentos()
        {
            var departamentos = new List<Departamento>
            {
                new Departamento
                {
                    codigo = 1,
                    nombre = "Ventas",
                    codigoEmpresa = 1,
                },
                new Departamento
                {
                    codigo = 2,
                    nombre = "Contabilidad",
                    codigoEmpresa = 1,
                },
                new Departamento
                {
                    codigo = 3,
                    nombre = "Ventas",
                    codigoEmpresa = 2,
                },
                new Departamento
                {
                    codigo = 4,
                    nombre = "Contabilidad",
                    codigoEmpresa = 2,
                },
            };
            return departamentos;
        }

        protected override void Seed(ContextoEmpresa contexto)
        {
            getUsuarios().ForEach(usuario => contexto.usuarios.Add(usuario));
            getAdministradores().ForEach(administrador => contexto.administradores.Add(administrador));
            getEmpresas().ForEach(empresa => contexto.empresas.Add(empresa));
            getDepartamentos().ForEach(departamento => contexto.departamentos.Add(departamento));
        }
    }
}