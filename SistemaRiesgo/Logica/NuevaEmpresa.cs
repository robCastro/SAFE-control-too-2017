using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaRiesgo.Models;

namespace SistemaRiesgo.Logica
{
    public class NuevaEmpresa
    {
        public bool agregarEmpresa(string nombre, string objetivos, string alcance, string idUsuario)
        {
            using (ContextoEmpresa db = new ContextoEmpresa())
            {
                int codigo;
                try
                {
                    codigo = (db.empresas != null && db.empresas.Any()) ? db.empresas.Max(empresaAux => empresaAux.codigo) + 1 : 0;
                }
                catch (ArgumentNullException)
                {
                    codigo = 1;
                }
                var empresa = new Empresa();
                empresa.codigo = codigo;
                empresa.nombre = nombre; 
                empresa.objetivos = objetivos;
                empresa.alcance = alcance;
                empresa.idAdmin = idUsuario;
                    //idUsuario es el correo del admin loggeado. Este correo es extraido
                    //en la pantalla CrearEmpresa.aspx
                db.empresas.Add(empresa);
                db.SaveChanges();
            }
            return true;
        }

        public bool actualizarEmpresa(int codigo, string nombre, string objetivos, string alcance, Empresa empresa)
        {
            
            using (var db = new ContextoEmpresa())
            {
                empresa.nombre = nombre;
                empresa.objetivos = objetivos;
                empresa.alcance = alcance;
                db.Entry(empresa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return true;
        }

    }

    
}