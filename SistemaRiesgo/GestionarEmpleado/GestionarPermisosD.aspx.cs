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

namespace SistemaRiesgo.GestionarEmpleado
{
    public partial class GestionarPermisosD : System.Web.UI.Page
    {
        private Empresa empresa = new Empresa();    //empresa actual
        private Empleado empleado = new Empleado(); //empleado que vamos a modificar
        private Departamento departamento = new Departamento();
        private bool idEmpleadoValido = false;      //boolean de id valido
        private bool idDepartamentoValido = false;
        ApplicationUser usuario = new ApplicationUser(); //usuario del empleado a modificar
        private List<string> rolesDeUsuario = new List<string>(); //roles en los que se encuentra el usuario

        protected void Page_Load(object sender, EventArgs e)
        {
           
            string parametroIdEmpleado = Request.QueryString["idEmpleado"];
            string parametroIdDepartamento = Request.QueryString["idDepartamento"];
            int idEmpleado;
            int idDepartamento;
            idEmpleadoValido = Int32.TryParse(parametroIdEmpleado, out idEmpleado);
            idDepartamentoValido = Int32.TryParse(parametroIdDepartamento, out idDepartamento);
#region Validacion
            if (!idEmpleadoValido || !idDepartamentoValido)
            {
                parametroInvalido("Solo numeros en los parametros por favor.");
                return; //terminando en caso de parametro Invalido
            }
            else
            {
                using (ContextoEmpresa db = new ContextoEmpresa())
                {
                        //Departamento al que pertenece el empleado cuyos permisos se modificarán
                    departamento = db.departamentos.Where(depAux => depAux.codigo == idDepartamento).FirstOrDefault();
                    if (departamento == null)
                    {
                        parametroInvalido("No existe este departamento.");
                        return;
                    }
                    else
                    {
                            //empleado loggeado actualmente, si es admin será null
                        Empleado empleadoLoggeado = db.empleados.Where(empAux => empAux.idUsuario == Context.User.Identity.Name).FirstOrDefault();
                            //empresa del admin, si es empleado con permisos de gestion sera null
                        empresa = db.empresas.Where(empresaAux => empresaAux.idAdmin == Context.User.Identity.Name).FirstOrDefault();
                            //si ambos son null entonces  no puede modificar permisos
                        if (empleadoLoggeado == null && empresa == null)
                        {
                            msjExito.Text = "EmpleadoLoggeado y Empresa Null"; //eliminar
                            parametroInvalido("No tiene permisos para este Departamento.");
                            return;
                        }
                            //si el empleado no es admin o si no pertenece a este dpto no puede hacer cambios para este empleado.
                            //se sabe que es admin gracias al webconfig, pero se sabe que es admin de esta empresa gracias al
                            //que sacamos la empresa con admin loggeado en el if anterior. Pero si no es admin puede que tenga permisos 
                            //para modificar empleados (se valida tambien con el webconfig) pero solo de su departamento, 
                            //cosa que se valida en el otro extremo del or. Si no cumple alguna de las 2 es invalido.
                                

                        if (empleadoLoggeado == null && empresa.codigo == departamento.codigoEmpresa)
                        {
                                //empleado a modificar
                            empleado = db.empleados.Where(empAux => empAux.codigo == idEmpleado).FirstOrDefault();
                            if (empleado == null)
                            {
                                parametroInvalido("No existe este empleado.");
                                return;
                            }
                            else
                            {
                                if (empleado.codDepartamento != departamento.codigo)
                                {
                                    parametroInvalido("El empleado no pertenece al Departamento especificado");
                                    return;
                                }
                                lblNombreEmpleado.Text = empleado.nombre;
                            }
                        }
                        else
                        {
                            parametroInvalido("Este Departamento no es de su Empresa");
                        }

                        if (empresa == null && empleadoLoggeado.codDepartamento == departamento.codigo)
                        {
                                //empleado a modificar
                            empleado = db.empleados.Where(empAux => empAux.codigo == idEmpleado).FirstOrDefault();
                            if (empleado == null)
                            {
                                parametroInvalido("No existe este empleado.");
                                return;
                            }
                            else
                            {
                                if (empleado.codDepartamento != departamento.codigo)
                                {
                                    parametroInvalido("El empleado no pertenece al Departamento especificado");
                                    return;
                                }
                                lblNombreEmpleado.Text = empleado.nombre;
                            }
                        }
                          
                    }
                }
            } 
#endregion
            //FIN DE VALIDACIONES

            //extrayendo roles
            #region roles
            using (ApplicationDbContext dbVisualStudio = new ApplicationDbContext())
            {
                var manager = new UserManager();
                usuario = manager.FindByEmail(empleado.idUsuario);
                if (usuario != null)
                {
                    var roles = usuario.Roles.ToList();
                    if (roles != null)
                    {
                        foreach(IdentityUserRole rolUser in roles){
                            var rol = dbVisualStudio.Roles.Find(rolUser.RoleId);
                            if (rol != null)
                            {
                                if (rol.Name.Equals("EjeTar"))
                                {
                                    rolesDeUsuario.Add("EjeTar");
                                    if (!IsPostBack) //si no es refresh
                                        ejecutarTar.Checked = true;
                                    continue; //saltar a siguiente rol
                                }
                                if (rol.Name.Equals("RegAct"))
                                {
                                    rolesDeUsuario.Add("RegAct");
                                    if (!IsPostBack) //si no es refresh
                                        registrarAct.Checked = true;
                                    continue; //saltar a siguiente rol
                                }
                                if (rol.Name.Equals("ConTar"))
                                {
                                    rolesDeUsuario.Add("ConTar");
                                    if (!IsPostBack) //si no es refresh
                                        confirmarEjec.Checked = true;
                                    continue; //saltar a siguiente rol
                                }
                                if (rol.Name.Equals("AdminEmp"))
                                {
                                    rolesDeUsuario.Add("AdminEmp");
                                    if (!IsPostBack) //si no es refresh
                                        administrarEmp.Checked = true;
                                    continue; //saltar a siguiente rol
                                }
                                if (rol.Name.Equals("DecRie"))
                                {
                                    rolesDeUsuario.Add("DecRie");
                                    if (!IsPostBack) //si no es refresh
                                        decidirRiesgo.Checked = true;
                                    continue; //saltar a siguiente rol
                                }
                                if (rol.Name.Equals("AsigTar"))
                                {
                                    rolesDeUsuario.Add("AsigTar");
                                    if (!IsPostBack) //si no es refresh
                                        asignarTareas.Checked = true;
                                    continue; //saltar a siguiente rol
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }
        private void parametroInvalido(string msj)
        {
            msjError.Text = msj;
            divNombreEmpleado.Visible = false;
            tablaPermisos.Visible = false;
            tablaBotones.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ApplicationDbContext dbVisualStudio = new ApplicationDbContext();
            UserManager manager = new UserManager();
            IdentityResult resultado = new IdentityResult();
            if (ejecutarTar.Checked)
            {
                if (!rolesDeUsuario.Contains("EjeTar"))
                {
                    resultado = manager.AddToRole(manager.FindByEmail(empleado.idUsuario).Id, "Ejetar");
                    if (!resultado.Succeeded)
                        msjError.Text = resultado.Errors.FirstOrDefault();
                }
            }
            else
            {
                if (rolesDeUsuario.Contains("EjeTar"))
                {
                    resultado = manager.RemoveFromRole(usuario.Id, "EjeTar");
                    if (!resultado.Succeeded)
                        msjError.Text = resultado.Errors.FirstOrDefault();
                }
            }
            if (registrarAct.Checked)
            {
                if (!rolesDeUsuario.Contains("RegAct"))
                {
                    resultado = manager.AddToRole(manager.FindByEmail(empleado.idUsuario).Id, "RegAct");
                    if (!resultado.Succeeded)
                        msjError.Text = resultado.Errors.FirstOrDefault();
                }
            }
            else
            {
                if (rolesDeUsuario.Contains("RegAct"))
                {
                    resultado = manager.RemoveFromRole(usuario.Id, "RegAct");
                    if (!resultado.Succeeded)
                        msjError.Text = resultado.Errors.FirstOrDefault();
                }
            }
            if (confirmarEjec.Checked==true)
            {
                if (!rolesDeUsuario.Contains("ConTar"))
                {
                    resultado = manager.AddToRole(manager.FindByEmail(empleado.idUsuario).Id, "ConTar");
                    if (!resultado.Succeeded)
                        msjError.Text = resultado.Errors.FirstOrDefault();
                }
            }
            else
            {
                if (rolesDeUsuario.Contains("ConTar"))
                {
                    resultado = manager.RemoveFromRole(usuario.Id, "ConTar");
                    if (!resultado.Succeeded)
                        msjError.Text = resultado.Errors.FirstOrDefault();
                }
            }
            if (administrarEmp.Checked)
            {
                if (!rolesDeUsuario.Contains("AdminEmp"))
                {
                    resultado = manager.AddToRole(manager.FindByEmail(empleado.idUsuario).Id, "AdminEmp");
                    if (!resultado.Succeeded)
                        msjError.Text = resultado.Errors.FirstOrDefault();
                }
            }
            else
            {
                if (rolesDeUsuario.Contains("AdminEmp"))
                {
                    resultado = manager.RemoveFromRole(usuario.Id, "AdminEmp");
                    if (!resultado.Succeeded)
                        msjError.Text = resultado.Errors.FirstOrDefault();
                }
            }
            if (decidirRiesgo.Checked)
            {
                if (!rolesDeUsuario.Contains("DecRie"))
                {
                    resultado = manager.AddToRole(manager.FindByEmail(empleado.idUsuario).Id, "DecRie");
                    if (!resultado.Succeeded)
                        msjError.Text = resultado.Errors.FirstOrDefault();
                }
            }
            else
            {
                if (rolesDeUsuario.Contains("DecRie"))
                {
                    resultado = manager.RemoveFromRole(usuario.Id, "DecRie");
                    if (!resultado.Succeeded)
                        msjError.Text = resultado.Errors.FirstOrDefault();
                }
            }
            if (asignarTareas.Checked)
            {
                if (!rolesDeUsuario.Contains("AsigTar"))
                {
                    resultado = manager.AddToRole(manager.FindByEmail(empleado.idUsuario).Id, "AsigTar");
                    if (!resultado.Succeeded)
                        msjError.Text = resultado.Errors.FirstOrDefault();
                }
            }
            else
            {
                if (rolesDeUsuario.Contains("AsigTar"))
                {
                    resultado = manager.RemoveFromRole(usuario.Id, "AsigTar");
                    if (!resultado.Succeeded)
                        msjError.Text = resultado.Errors.FirstOrDefault();
                }
            }
            msjExito.Text = "Permisos de Usuario Guardados.";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GestionarEmpleado/ListaEmpleados?id=" + departamento.codigo);
        }


    }
}