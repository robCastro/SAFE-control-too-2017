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
    public partial class CrearEmpresa : System.Web.UI.Page
    {
        private Empresa empresa = new Empresa();
        protected void Page_Load(object sender, EventArgs e)
        {
            string accion = Request.QueryString["accion"];
            if (accion == "agregar"){
                lblStatus.Text = "Empresa Creada! Puede crear departamentos en Menu de Acciones";
            }
            else { 
                if(accion == "modificar")
                    lblStatus.Text = "Cambios Almacenados! Puede crear departamentos en Menu de Acciones";
            }
            using (ContextoEmpresa db = new ContextoEmpresa())
            {
                    //extrayendo empresa actual
                empresa = db.empresas.Where(empresaAux => empresaAux.idAdmin == Context.User.Identity.Name).FirstOrDefault();
            }    
                    //si la empresa ya existe
                if (empresa != null)
                {
                        //redirige a editar empresa
                    Response.Redirect("EditarEmpresa");
                }
        }

        protected void btnNuevaEmpresa_Click(object sender, EventArgs e)
        {
            NuevaEmpresa auxiliar = new NuevaEmpresa();
            if (empresa == null) {

                bool guardadoCorrectamente = auxiliar.agregarEmpresa(NombreEmpresa.Text, objetivos.Text, alcance.Text, Context.User.Identity.Name);
                    //El comando Context.User.Identity.Name extrae el email de la persona loggeada actualmente
                    //para que sea el admin de esta empresa
                if (guardadoCorrectamente)
                {

                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?accion=agregar"); //page load de arriba recibe este argumento
                }
                else
                {
                    lblStatus.Text = "No se pudo guardar el departamento";
                }
            }
            /*else
            {
                if (NombreEmpresa.Text != null)
                {
                    empresa.nombre = NombreEmpresa.Text;
                }
                else
                    RequiredFieldValidator1.IsValid = true;
                    
                if (objetivos.Text != null)
                    empresa.objetivos = objetivos.Text;
                if (alcance.Text != null)
                    empresa.alcance = alcance.Text;
                using (var conexion = new ContextoEmpresa())
                {
                    conexion.Entry(empresa).State = System.Data.Entity.EntityState.Modified;
                    conexion.SaveChanges();
                }
                    //extrayendo url Actual
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?accion=modificar"); //page load de arriba recibe este argumento
                    //redirigiendo a url actual más un parametro
            }*/
        }
    }
}