using Microsoft.Owin;
using Owin;
using SistemaRiesgo.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

[assembly: OwinStartupAttribute(typeof(SistemaRiesgo.Startup))]
namespace SistemaRiesgo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }

        public static void crearRoles() //creando los roles básicos del sistema
        {
            using (ApplicationDbContext dbVisualStudio = new ApplicationDbContext())
            {
                    //nuevo gestor de Roles
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbVisualStudio));
                
                        //Roles Globales de la Empresa
                    if (!roleManager.RoleExists("ClaAct")) //si no existe el rol crearlo
                    {
                        var rol = new IdentityRole();
                        rol.Name = "ClaAct";
                        roleManager.Create(rol);
                    }
                    if (!roleManager.RoleExists("AsigVul")) //si no existe el rol crearlo
                    {
                        var rol = new IdentityRole();
                        rol.Name = "AsigVul";
                        roleManager.Create(rol);
                    }
                    if (!roleManager.RoleExists("GesVul")) //si no existe el rol crearlo
                    {
                        var rol = new IdentityRole();
                        rol.Name = "GesVul";
                        roleManager.Create(rol);
                    }
                    if (!roleManager.RoleExists("GesAmen")) //si no existe el rol crearlo
                    {
                        var rol = new IdentityRole();
                        rol.Name = "GesAmen";
                        roleManager.Create(rol);
                    }
                    if (!roleManager.RoleExists("GesPlan")) //si no existe el rol crearlo
                    {
                        var rol = new IdentityRole();
                        rol.Name = "GesPlan";
                        roleManager.Create(rol);
                    }
                    if (!roleManager.RoleExists("AsigPlan")) //si no existe el rol crearlo
                    {
                        var rol = new IdentityRole();
                        rol.Name = "AsigPlan";
                        roleManager.Create(rol);
                    }
            
                        //Roles de Departamento
            } 
        }
    }
}
