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
using System.Threading.Tasks;


namespace SistemaRiesgo.Admin
{
    public partial class GestionarPermisosG : System.Web.UI.Page
    {
        private Empresa empresa = new Empresa();
        private Empleado empleado = new Empleado();
        private bool idEmpleadoValido = false;
        ApplicationUser usuario = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //si no es un refresh
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
                        if (empleado == null)
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
                                usuario = dbVisualStudio.Users.Where(aux => aux.Email == empleado.idUsuario).FirstOrDefault();
                                if (usuario != null)
                                {
                                    lblNombreEmpleado.Text = empleado.nombre;
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
            } //fin de if !IsPostBack
            
        }

        public async Task DeleteRolesAsync(List<string> deleteList, string userId)
        {
            if (userId != null)
            {
                UserManager manager = new UserManager();
                foreach (var roleName in deleteList)
                {
                    IdentityResult deletionResult = await manager.RemoveFromRoleAsync(roleName, userId);
                }
            }
        }
        public void btnGuardarClic(object sender, EventArgs e)
        {
            List<string> rolesEliminar = new List<string>();


            ApplicationDbContext dbVisualStudio = new ApplicationDbContext();
            
            var roleStore = new RoleStore<IdentityRole>(dbVisualStudio); //almacen de roles
            var roleMgr = new RoleManager<IdentityRole>(roleStore); //manager de roles para el almacen
            var manager = new UserManager();
            IdentityResult resultado;
            msjAuxiliar2.Text = "Clic en Guardar";
            
            try{    //try para manejar añadir a rol si ya esta en él y eliminar rol si no está en él
                if (clasificarActivos.Checked)
                {
                    manager.AddToRole(usuario.Id, "ClaAct");
                }
                else
                {
                    //resultado = manager.RemoveFromRole(usuario.Id, "ClaAct");
                    rolesEliminar.Add("ClaAct");
                }
            }
            catch (InvalidOperationException)
            { msjAuxiliar2.Text = "Eliminado de Clasificar Activos"; }
            finally
            {
                try
                {
                    if (asignarVuln.Checked)
                        manager.AddToRole(usuario.Id, "AsigVul");
                    else
                        manager.RemoveFromRole(usuario.Id, "AsigVul");
                }
                catch (InvalidOperationException)
                { }
                finally
                {
                    try
                    {
                        if (gestionarVuln.Checked)
                            manager.AddToRole(usuario.Id, "GesVul");
                        else
                            manager.RemoveFromRole(usuario.Id, "GesVul");
                    }
                    catch (InvalidOperationException)
                    { }
                    finally
                    {
                        try
                        {

                            if (gestionarAmen.Checked)
                                manager.AddToRole(usuario.Id, "GesAmen");
                            else
                                manager.RemoveFromRole(usuario.Id, "GesAmen");
                        }
                        catch (InvalidOperationException)
                        { }
                        finally
                        {
                            try
                            {
                                if (gestionarPlan.Checked)
                                    manager.AddToRole(usuario.Id, "GesPlan");
                                else
                                    manager.RemoveFromRole(usuario.Id, "GesPlan");
                            }
                            catch (InvalidOperationException)
                            { }
                            finally
                            {
                                try
                                {
                                    if (asignarPlan.Checked)
                                        manager.AddToRole(usuario.Id, "AsigPlan");
                                    else
                                        manager.RemoveFromRole(usuario.Id, "AsigPlan");
                                }
                                catch (InvalidOperationException)
                                { }
                                finally
                                {
                                    DeleteRolesAsync(rolesEliminar, usuario.Id);
                                }
                            }
                            
                        }
                        
                    }
                    
                }
            }
            
        }

        protected void clasificarActivos_CheckedChanged(object sender, EventArgs e)
        {
            /*if (clasificarActivos.Checked)
            {
                msjAuxiliar2.Text = "Checked";
            }
            else
                msjAuxiliar2.Text = "Not Checked";*/
        }

        protected void asignarPlan_CheckedChanged(object sender, EventArgs e)
        {
            /*if (asignarPlan.Checked)
            {
                msjAuxiliar2.Text = "Checked";
            }
            else
                msjAuxiliar2.Text = "Not Checked";*/
        }



    }
}