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

namespace SistemaRiesgo.GestionarEmpleado
{
    public partial class ListaEmpleados : System.Web.UI.Page
    {
        String idEmpleado;
        int idDepartamento;
        Departamento depto = new Departamento();
        Empleado empleado = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null)
            {
                TextBox1.Text = Request.Params["id"];
            }
            using (var db = new ContextoEmpresa())
            {
                depto = db.departamentos.Where(deptoAux => deptoAux.codigo == idDepartamento).FirstOrDefault();
                empleado = db.empleados.Where(empleAux => empleAux.idUsuario == Context.User.Identity.Name).FirstOrDefault();
            }
            if (depto == null)
            {
                btnNuevo.Visible = false;
            }
            else
            {
                string mensajeAccion = Request.QueryString["accion"];
                if (mensajeAccion == "eliminar")
                    accion.Text = "Empleado Eliminado";
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            idEmpleado = GridView1.SelectedRow.Cells[1].Text;
            GPermit.Visible = true;
        }

        protected void GPermit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GestionarEmpleado/GestionarPermisosD.aspx?idEmpleado=" + empleado.codigo);
            Response.Redirect("~/GestionarEmpleado/GestionarPermisosD.aspx?idDepartamento=" + idDepartamento);
        }
    }
}