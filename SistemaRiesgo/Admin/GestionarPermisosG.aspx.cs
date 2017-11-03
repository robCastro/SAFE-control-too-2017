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
        private List<string> rolesDeUsuario = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack) //si no es un refresh
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
                                //usuario = dbVisualStudio.Users.Where(aux => aux.Email == empleado.idUsuario).FirstOrDefault();
                                var manager = new UserManager();
                                usuario = manager.FindByEmail(empleado.idUsuario);
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
                                                    rolesDeUsuario.Add("ClaAct");
                                                    if (!IsPostBack)
                                                    clasificarActivos.Checked = true;
                                                    continue;
                                                } //saltar a siguiente rol
                                                if (rol.Name.Equals("AsigVul"))
                                                {
                                                    rolesDeUsuario.Add("AsigVul");
                                                    if (!IsPostBack)
                                                    asignarVuln.Checked = true;
                                                    continue;
                                                } //saltar a siguiente rol
                                                if (rol.Name.Equals("GesVul"))
                                                {
                                                    rolesDeUsuario.Add("GesVul");
                                                    if (!IsPostBack)
                                                    gestionarVuln.Checked = true;
                                                    continue;
                                                } //saltar a siguiente rol
                                                if (rol.Name.Equals("GesAmen"))
                                                {
                                                    rolesDeUsuario.Add("GesAmen");
                                                    if (!IsPostBack)
                                                    gestionarAmen.Checked = true;
                                                    continue;
                                                } //saltar a siguiente rol
                                                if (rol.Name.Equals("GesPlan"))
                                                {
                                                    rolesDeUsuario.Add("GesPlan");
                                                    if (!IsPostBack)
                                                    gestionarPlan.Checked = true;
                                                    continue;
                                                } //saltar a siguiente rol
                                                if (rol.Name.Equals("AsigPlan"))
                                                {
                                                    rolesDeUsuario.Add("AsigPlan");
                                                    if (!IsPostBack)
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


        // No implementado
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

        // No implementado
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
            {  }
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
                                    //RegisterAsyncTask(new PageAsyncTask(DeleteRolesAsync(rolesEliminar, usuario.Id)));
                                    //DeleteRolesAsync(rolesEliminar, usuario.Id);
                                }
                            }
                            
                        }
                        
                    }
                    
                }
            }
            
        }

        public void cambiosRol()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var manager = new UserManager();
            //var roleStore = new RoleStore<IdentityRole>(context);
            //var roleMgr = new RoleManager<IdentityRole>(roleStore);
            IdentityResult resultado = new IdentityResult();
            if (clasificarActivos.Checked)
            {
                if (!rolesDeUsuario.Contains("ClaAct"))
                {
                    resultado = manager.AddToRole(manager.FindByEmail(empleado.idUsuario).Id, "ClaAct");
                    if (!resultado.Succeeded)
                        msjAuxiliar2.Text = resultado.Errors.FirstOrDefault();
                }
            }
            else
            {
                if (rolesDeUsuario.Contains("ClaAct"))
                {
                    resultado = manager.RemoveFromRole(usuario.Id, "ClaAct");
                    if (!resultado.Succeeded)
                        msjAuxiliar2.Text = resultado.Errors.FirstOrDefault();
                }
            }


            if (asignarVuln.Checked)
            {
                if (!rolesDeUsuario.Contains("AsigVul"))
                {
                    resultado = manager.AddToRole(manager.FindByEmail(empleado.idUsuario).Id, "AsigVul");
                    if (!resultado.Succeeded)
                        msjAuxiliar2.Text = resultado.Errors.FirstOrDefault();
                }
            }
            else
            {
                if (rolesDeUsuario.Contains("AsigVul"))
                {
                    resultado = manager.RemoveFromRole(usuario.Id, "AsigVul");
                    if (!resultado.Succeeded)
                        msjAuxiliar2.Text = resultado.Errors.FirstOrDefault();
                }
            }


            if (gestionarVuln.Checked)
            {
                if (!rolesDeUsuario.Contains("GesVul"))
                {
                    resultado = manager.AddToRole(manager.FindByEmail(empleado.idUsuario).Id, "GesVul");
                    if (!resultado.Succeeded)
                        msjAuxiliar2.Text = resultado.Errors.FirstOrDefault();
                }
            }
            else
            {
                if (rolesDeUsuario.Contains("GesVul"))
                {
                    resultado = manager.RemoveFromRole(usuario.Id, "GesVul");
                    if (!resultado.Succeeded)
                        msjAuxiliar2.Text = resultado.Errors.FirstOrDefault();
                }
            }


            if (gestionarAmen.Checked)
            {
                if (!rolesDeUsuario.Contains("GesAmen"))
                {
                    resultado = manager.AddToRole(manager.FindByEmail(empleado.idUsuario).Id, "GesAmen");
                    if (!resultado.Succeeded)
                        msjAuxiliar2.Text = resultado.Errors.FirstOrDefault();
                }
            }
            else
            {
                if (rolesDeUsuario.Contains("GesAmen"))
                {
                    resultado = manager.RemoveFromRole(usuario.Id, "GesAmen");
                    if (!resultado.Succeeded)
                        msjAuxiliar2.Text = resultado.Errors.FirstOrDefault();
                }
            }


            if (gestionarPlan.Checked)
            {
                if (!rolesDeUsuario.Contains("GesPlan"))
                {
                    resultado = manager.AddToRole(manager.FindByEmail(empleado.idUsuario).Id, "GesPlan");
                    if (!resultado.Succeeded)
                        msjAuxiliar2.Text = resultado.Errors.FirstOrDefault();
                }
            }
            else
            {
                if (rolesDeUsuario.Contains("GesPlan"))
                {
                    resultado = manager.RemoveFromRole(usuario.Id, "GesPlan");
                    if (!resultado.Succeeded)
                        msjAuxiliar2.Text = resultado.Errors.FirstOrDefault();
                }
            }


            if (asignarPlan.Checked)
            {
                if (!rolesDeUsuario.Contains("AsigPlan"))
                {
                    resultado = manager.AddToRole(manager.FindByEmail(empleado.idUsuario).Id, "AsigPlan");
                    if (!resultado.Succeeded)
                        msjAuxiliar2.Text = resultado.Errors.FirstOrDefault();
                }
            }
            else
            {
                if (rolesDeUsuario.Contains("AsigPlan"))
                {
                    resultado = manager.RemoveFromRole(usuario.Id, "AsigPlan");
                    if (!resultado.Succeeded)
                        msjAuxiliar2.Text = resultado.Errors.FirstOrDefault();
                }
            }
        }


        protected void Unnamed_Click(object sender, EventArgs e)
        {
            cambiosRol();
            msjExito.Text = "Cambios en Roles Guardados";
        }
    }
}