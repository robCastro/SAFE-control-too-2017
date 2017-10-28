using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaRiesgo.Models;

namespace SistemaRiesgo.Admin
{
    public partial class EditarEmpresa : System.Web.UI.Page
    {
        private Empresa empresa = new Empresa();


        protected void Page_Load(object sender, EventArgs e)
        {
            using (ContextoEmpresa db2 = new ContextoEmpresa())
            {
                empresa = db2.empresas.Where(empresaAux => empresaAux.idAdmin == Context.User.Identity.Name).FirstOrDefault();
            }
            if (empresa == null)
                Response.Redirect("CrearEmpresa");

        }

        
        
        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<SistemaRiesgo.Models.Empresa> miEmpresa_GetData()
        {
            ContextoEmpresa db = new ContextoEmpresa();
            
                IQueryable<Empresa> query = db.empresas;
                query = query.Where(empresaAux => empresaAux.codigo == empresa.codigo);
                return query;
            
            
        }

        
        
        public void miEmpresa_UpdateItem(int codigo)
        {
            using (ContextoEmpresa db = new ContextoEmpresa())
            {
                Empresa item = null;
                item = db.empresas.Find(codigo);
                if (item == null)
                {
                    ModelState.AddModelError("",
              String.Format("Empresa con codigo {0} no fue Encontrada", codigo));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    db.SaveChanges();
                }
            }
        }
    }
}