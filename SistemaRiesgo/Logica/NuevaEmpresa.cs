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
                    codigo = db.empresas.Max(empresaAux => empresaAux.codigo) + 1;
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
                
                db.empresas.Add(empresa);
                db.SaveChanges();
            }
            return true;
        }

        public bool actualizarEmpresa(int codigo, string nombre, string objetivos, string alcance, Empresa empresa)
        {
            
            using (var db = new ContextoEmpresa())
            {
                
                //var empresa = db.empresas.Where(empresaAux => empresaAux.codigo == codigo).FirstOrDefault();
                
                 
            
                empresa.nombre = nombre;
                empresa.objetivos = objetivos;
                empresa.alcance = alcance;

                db.Entry(empresa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                
                /*empresa = db.empresas.Find(empresa.codigo);
                empresa.objetivos = objetivos;
                empresa.alcance = alcance;
                empresa.nombre = nombre;
                db.Entry(empresa).CurrentValues.SetValues(empresa);
                db.SaveChanges();*/
            }
            return true;
        }

    }

    
}