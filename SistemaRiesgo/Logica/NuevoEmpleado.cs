
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaRiesgo.Models;

namespace SistemaRiesgo.Logica
{
    public class NuevoEmpleado
    {
        public bool agregarEmpleado(string nombre, string usuario,int codigoEmpresa, int codDepto )
        {
            using (ContextoEmpresa db = new ContextoEmpresa())
            {
                int codigo;
                try
                {
                    codigo = (db.empleados != null && db.empleados.Any()) ? db.empleados.Max(departamentoAux => departamentoAux.codigo) + 1 : 0;
                }
                catch (ArgumentNullException)
                {
                    codigo = 1;
                }
                var empleado = new Empleado();
                empleado.codigo = codigo;
                empleado.codDepartamento = codDepto; 
                empleado.codEmpresa=codigoEmpresa;
                empleado.nombre = nombre;
                empleado.idUsuario = usuario;
                db.empleados.Add(empleado);
                db.SaveChanges();

 

            }
            return true;
        }
    }
}