using Microsoft.AspNet.Identity;                    //necesarios para extraer usuario mediante email
using Microsoft.AspNet.Identity.EntityFramework;    //necesarios para extraer usuario mediante email
using Microsoft.AspNet.Identity.Owin;               //necesarios para extraer usuario mediante email
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SistemaRiesgo.Models;


namespace SistemaRiesgo.Admin
{
    public partial class GestionarPermisosG : System.Web.UI.Page
    {
        private Empresa empresa = new Empresa();
        private Empleado empleado;
        private bool idEmpleadoValido = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ContextoEmpresa db = new ContextoEmpresa())
            {
                empresa = db.empresas.Where(empresaAux => empresaAux.idAdmin == Context.User.Identity.Name).FirstOrDefault();
            }
            
            if (empresa == null)
            {
                Response.Redirect("CrearEmpresa");
            }
            else
            {
                string parametroIdEmpleado = Request.QueryString["idEmpleado"];
                int idEmpleado;
                idEmpleadoValido = Int32.TryParse(parametroIdEmpleado, out idEmpleado);
                if (!idEmpleadoValido)
                {
                    lblUsuarioInvalido.Visible = true;
                    divNombreEmpleado.Visible = false;
                    tablaPermisos.Visible = false;
                    tablaBotones.Visible = false;
                }
                else
                {
                    using (ContextoEmpresa db = new ContextoEmpresa())
                    {
                        //extrayendo el empleado
                        empleado = db.empleados.Where(empleadoAux => empleadoAux.codEmpresa == empresa.codigo && empleadoAux.codigo == idEmpleado).FirstOrDefault();
                    }
                    if (empleado==null)
                    {
                        lblUsuarioInvalido.Visible = true;
                        divNombreEmpleado.Visible = false;
                        tablaPermisos.Visible = false;
                        tablaBotones.Visible = false;
                    }
                    else
                    {
                        //var manager = new UserManager();
                            //extrayendo usuario mediante email
                        //ApplicationUser user = manager.FindByEmail(empleado.idUsuario);
                        using (ApplicationDbContext dbVisualStudio = new ApplicationDbContext())
                        {
                            ApplicationUser usuario = dbVisualStudio.Users.Where(aux => aux.Email == empleado.idUsuario).FirstOrDefault();
                            if (usuario != null)
                            {
                                var roles = usuario.Roles.ToList();
                                if (roles != null)
                                {
                                    /*roles.ForEach(delegate(IdentityUserRole rolUser) //rolUser relaciona Rol con usuario, no es el rol como tal
                                    {
                                        var rol = dbVisualStudio.Roles.Find(rolUser.RoleId);
                                        if (rol != null)
                                        {
                                            if (rol.Name.Equals("ClaAct"))
                                            {
                                                clasificarActivos.Checked = true;
                                                continue; //saltar a siguiente rol
                                            }


                                        }

                                    });*/
                                    foreach (IdentityUserRole rolUser in roles) //rolUser relaciona Rol con usuario, no es el rol como tal
                                    {
                                        var rol = dbVisualStudio.Roles.Find(rolUser.RoleId);
                                        if (rol != null)
                                        {
                                            if (rol.Name.Equals("ClaAct"))
                                            {
                                                clasificarActivos.Checked = true;
                                                continue;
                                            } //saltar a siguiente rol
                                            if (rol.Name.Equals("AsigVul"))
                                            {
                                                asignarVuln.Checked = true;
                                                continue;
                                            } //saltar a siguiente rol
                                            if (rol.Name.Equals("GesVul"))
                                            {
                                                gestionarVuln.Checked = true;
                                                continue;
                                            } //saltar a siguiente rol
                                            if (rol.Name.Equals("GesAmen"))
                                            {
                                                gestionarAmen.Checked = true;
                                                continue;
                                            } //saltar a siguiente rol
                                            if (rol.Name.Equals("GesPlan"))
                                            {
                                                gestionarPlan.Checked = true;
                                                continue;
                                            } //saltar a siguiente rol
                                            if (rol.Name.Equals("AsigPlan"))
                                            {
                                                asignarPlan.Checked = true;
                                                continue;
                                            } //saltar a siguiente rol
                                        }
                                        lblNombreEmpleado.Text = empleado.nombre;
                                    }
                                }
                                else //si no hay roles para el usuario
                                {

                                }
                            }
                            else //si usuario es nulo
                            {
                                lblUsuarioInvalido.Visible = true;
                                divNombreEmpleado.Visible = false;
                                tablaPermisos.Visible = false;
                                tablaBotones.Visible = false;
                            }
                        }
                    }
                }
            }
        }


    }
}