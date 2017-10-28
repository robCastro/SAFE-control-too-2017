using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaRiesgo.Models;
using SistemaRiesgo.Logica;

namespace SistemaRiesgo.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        private Empresa empresa = new Empresa();
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new ContextoEmpresa())
            {
                empresa = db.empresas.Where(empresaAux => empresaAux.idAdmin == Context.User.Identity.Name).FirstOrDefault();
            }
            if (empresa == null)
                Response.Redirect("~/Admin/CrearEmpresa");
            string accion = Request.QueryString["accion"];
            if (accion == "agregar")
            {
                lblStatus.Text = "Departamento Guardado.";
                lblStatus.CssClass = "text-success";
            }
        }

        protected void btnGuardarYNuevoDepartamento_Click(object sender, EventArgs e)
        {
            guardar();
            // Reload the page.
            string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
            Response.Redirect(pageUrl + "?accion=agregar"); //page load de arriba recibe este argumento
               
        }

        protected void btnGuardarDepartamento_Click(object sender, EventArgs e)
        {
            guardar();
            Response.Redirect("ListaDepartamentos");
        }

        private void guardar()
        {
            NuevoDepartamento auxiliar = new NuevoDepartamento();
            bool guardadoCorrectamente = auxiliar.agregarDepartamento(NombreDepartamento.Text, empresa.codigo);
        }
    }
}