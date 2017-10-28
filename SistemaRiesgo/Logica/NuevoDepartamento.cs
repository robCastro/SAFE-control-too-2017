using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaRiesgo.Models;

namespace SistemaRiesgo.Logica
{
    public class NuevoDepartamento
    {
        public bool agregarDepartamento(string nombre, int codigoEmpresa)
        {
            using (ContextoEmpresa db = new ContextoEmpresa())
            {
                int codigo;
                try
                {
                    codigo = (db.departamentos != null && db.departamentos.Any()) ? db.departamentos.Max(departamentoAux => departamentoAux.codigo) + 1 : 0;
                }
                catch (ArgumentNullException)
                {
                    codigo = 1;
                }
                var departamento = new Departamento();
                departamento.codigo = codigo;
                departamento.codigoEmpresa = codigoEmpresa; 
                departamento.nombre = nombre;
                db.departamentos.Add(departamento);
                db.SaveChanges();
            }
            return true;
        }
    }
}