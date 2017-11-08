using Microsoft.AspNet.Identity;                    //necesarios para el uso de usuarios
using Microsoft.AspNet.Identity.EntityFramework;    //necesarios para el uso de usuarios
using Microsoft.AspNet.Identity.Owin;               //necesarios para el uso de usuarios
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
    public partial class CrearEmpleadoG : System.Web.UI.Page
    {
        private Empresa empresa = new Empresa();
        int IdDepto;
        protected void Page_Load(object sender, EventArgs e)
        {

            // en este caso no necesitamos IdDepto porque este empleado es global

            using (var db = new ContextoEmpresa())
            {
                //aca se extrae la empresa relacionada con el usuario que esta logueado
                empresa = db.empresas.Where(empresaAux => empresaAux.idAdmin == Context.User.Identity.Name).FirstOrDefault();
            }

            if (empresa == null)
            {
                Response.Redirect("~/Admin/CrearEmpresa");
            }
            string accion = Request.QueryString["accion"];

            if (accion == "agregar")
            {
                lblStatus.Text = "Empleado Guardado.";
                lblStatus.CssClass = "text-success";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //funciocita diseniada para guardar el registro de empleado en el depto
            guardar();
            // esto esta como opcion para retornar a la misma pagina de crear empleado
            string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
            //extrayendo redireccion actual
            Response.Redirect(pageUrl + "?accion=agregar"); //page load de arriba recibe este argumento
            //redirigiendo a pagina actual con parametro

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Aca la accion que se hara en Cancelar
        }

        //aqui la funcion para guardar al empleado 
        private void guardar()
        {
            // creado una instancia 
            NuevoEmpleado auxiliar = new NuevoEmpleado();

            //le pasamos como parametro el nombre del empleado , el codigo de la empresa, el usuario
            // null por el momento en departamento luego sincronizar con edwin

            //solicitar este parametro a edwin
            //
            int depto;
            depto = 0; //no acepta colocarle null solo al comparar con datos de la base de datos

            //UserName.Text le mando el email
            bool guardadoCorrectamente = auxiliar.agregarEmpleado(NombreEmpleado.Text, UserName.Text, empresa.codigo, depto);
            var manager = new UserManager();
            var user = new ApplicationUser() { UserName = UserName.Text, Email = UserName.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            //si se creo exitosamente

        }
    }
}