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
                //empleado = db.empleados.Where(empleAux => empleAux.idUsuario == Context.User.Identity.Name).FirstOrDefault();
            }
            if (depto == null)
            {
                MsjError.Visible = true;
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
            GridViewRow row = GridView1.SelectedRow;

            ListItem itemEmpl = new ListItem();
            itemEmpl.Text = Server.HtmlDecode(row.Cells[0].Text);

            idEmpleado = itemEmpl.Text;

            codSec.Text = idEmpleado;

            //idEmpleado = GridView1.SelectedRow.Cells[1].Text;
            GPermit.Visible = true;
        }

        public IQueryable<Empleado> getEmpleadosG()
        {
            if (depto == null)
            {
                return null;
            }
            else
            {
                var _db = new ContextoEmpresa();
                IQueryable<Empleado> query = _db.empleados;
                query = query.Where(empleado => empleado.codDepartamento != null && empleado.codDepartamento == idDepartamento);
                return query;
            }
        }



        public void listaEmpleadosG_DeleteItem(int codigo)
        {
            using (ContextoEmpresa db = new ContextoEmpresa())
            {
                var item = new Empleado { codigo = codigo };
                db.Entry(item).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("",
                    String.Format("Empleado con codigo {0} no existe", codigo));

                }
            }
        }


        public void listaEmpleadosG_UpdateItem(int codigo)
        {
            using (ContextoEmpresa db = new ContextoEmpresa())
            {
                Empleado item = null;
                item = db.empleados.Find(codigo);
                if (item == null)
                {
                    ModelState.AddModelError("",
              String.Format("Empleado con codigo {0} no fue Encontrado", codigo));
                    return;
                }
                TryUpdateModel(item);
                if (ModelState.IsValid)
                {
                    db.SaveChanges();
                }
            }
        }

        protected void GPermit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GestionarEmpleado/GestionarPermisosD.aspx?idEmpleado=" + empleado.codigo);
            Response.Redirect("~/GestionarEmpleado/GestionarPermisosD.aspx?idDepartamento=" + idDepartamento);
        }

        protected void ReturnD_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ListaDepartamentos.aspx");
        }

        protected void NvoEmpleado(object sender, EventArgs e)
        {
            //Response.Redirect("~/Admin/CrearEmpleado.aspx?IdDepto=" + idDepartamento);
        }
    }
}