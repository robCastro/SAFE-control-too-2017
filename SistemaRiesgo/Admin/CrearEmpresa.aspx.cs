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
                empresa = db.empresas.Where(empresaAux => empresaAux.idAdmin == Context.User.Identity.Name).FirstOrDefault();
            }    
                if (empresa != null)
                {

                    Response.Redirect("EditarEmpresa");
                    /*nombreAnterior.Text = "Nombre Anterior: ";
                    objetivoAnterior.Text = "Objetivos Anteriores: ";
                    alcanceAnterior.Text = "Alcance Anterior: ";
                    nombreAnterior.Text += empresa.nombre;
                    objetivoAnterior.Text += empresa.objetivos;
                    alcanceAnterior.Text += empresa.alcance;
                    RequiredFieldValidator1.EnableClientScript = false;*/

                }
                
            
        }

        protected void btnNuevaEmpresa_Click(object sender, EventArgs e)
        {
            NuevaEmpresa auxiliar = new NuevaEmpresa();
            if (empresa == null) {

                bool guardadoCorrectamente = auxiliar.agregarEmpresa(NombreEmpresa.Text, objetivos.Text, alcance.Text, Context.User.Identity.Name);
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
            else
            {
                //bool guardado = auxiliar.actualizarEmpresa(empresa.codigo, NombreEmpresa.Text, objetivos.Text, alcance.Text, empresa);
                
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

                

                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?accion=modificar"); //page load de arriba recibe este argumento
            }
        }
    }
}