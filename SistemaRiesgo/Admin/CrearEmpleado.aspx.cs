using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaRiesgo.Models;

namespace SistemaRiesgo.Admin
{
    public partial class CrearEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Empleado objEmpleado = GetEntity(); // se obtiene el objeto que se cree a traves de los datos insertados en el formulario

                // enviar a la capa de logica del negocio a NuevoEmpleado.cs


            }
        }

        private Empleado GetEntity()
        {

            Empleado objEmpleado = new Empleado();
            objEmpleado.nombre = NombreEmpleado.Text;
            objEmpleado.apellido = ApellidoEmpleado.Text;

            return objEmpleado;
        }
    }
}