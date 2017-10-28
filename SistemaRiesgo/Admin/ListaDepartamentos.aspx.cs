using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaRiesgo.Models;
using System.Web.ModelBinding;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace SistemaRiesgo
{
    public partial class ListaDepartamentos : System.Web.UI.Page
    {
        private Empresa empresa = new Empresa();
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new ContextoEmpresa())
            {
                empresa = db.empresas.Where(empresaAux => empresaAux.idAdmin == Context.User.Identity.Name).FirstOrDefault();
            }
            if (empresa == null)
            {
                mensaje.Text = "Debe Crear una Empresa Primero";
                btnNuevo.Visible = false;
            }
            else
            {
                string mensajeAccion = Request.QueryString["accion"];
                if (mensajeAccion == "eliminar")
                    accion.Text = "Departamento Eliminado";

            }
        }

        public IQueryable<Departamento> getDepartamentos(/*[QueryString("id")] int? codigo*/ )
        {
            if (empresa == null)
            {
                return null;
            }
            else { 
                var _db = new ContextoEmpresa();
                IQueryable<Departamento> query = _db.departamentos;
                query = query.Where(departamento => departamento.codigoEmpresa == empresa.codigo);
                return query;
            }
        }

        

        public void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearDepartamento");
        }
        
        
        public void btnEliminar_Click(object sender, EventArgs e)
        {
            if (listaDepartamentos.SelectedIndex >= 0)
            {
                using (var db = new ContextoEmpresa())
                {
                    /*int posicion = listaDepartamentos.SelectedIndex;
                    Departamento depa = new Departamento();
                    //int codigo = (int)((DataRowView)listaDepartamentos.Items.ElementAt(posicion).DataItem)["codigo"];
                    //DataRowView fila = (DataRowView)listaDepartamentos.Items.ElementAt(posicion).DataItem;
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                    DataRowView dataRow = (DataRowView)dataItem.DataItem;
                    string codigo = dataRow["codigo"].ToString();
                    /*string codstr = fila[1].ToString();
                    int codigo = int.Parse(codstr);
                    depa = db.departamentos.Where(depaAux => depaAux.codigo == codigo).FirstOrDefault();
                    db.departamentos.Remove(depa);
                    db.SaveChanges();
                    listaDepartamentos.SelectedIndex = -1;
                    
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?accion=eliminar");
                    
                    accion.Text = codigo;*/
                    //listaDepartamentos.DeleteItem(listaDepartamentos.SelectedIndex);
                }
            }
            else
            {
                accion.Text = "No seleccionó un Departamento";
            }
            
        }

        
        // The id parameter name should match the DataKeyNames value set on the control
        public void listaDepartamentos_DeleteItem(int codigo)
        {
            using (ContextoEmpresa db = new ContextoEmpresa())
            {
                var item = new Departamento { codigo = codigo };
                db.Entry(item).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", 
                    String.Format("Departamento con codigo {0} no existe", codigo));
                
                }
            }
        }

        
        // The id parameter name should match the DataKeyNames value set on the control
        public void listaDepartamentos_UpdateItem(int codigo)
        {
            using (ContextoEmpresa db = new ContextoEmpresa())
            {
                Departamento item = null;
                item = db.departamentos.Find(codigo);
                if (item == null)
                {
                    ModelState.AddModelError("",
              String.Format("Departamento con codigo {0} no fue Encontrado", codigo));
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