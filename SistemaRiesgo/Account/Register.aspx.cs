using Microsoft.AspNet.Identity;                    //necesarios para el uso de usuarios
using Microsoft.AspNet.Identity.EntityFramework;    //necesarios para el uso de usuarios
using Microsoft.AspNet.Identity.Owin;               //necesarios para el uso de usuarios
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using SistemaRiesgo.Models;
using SistemaRiesgo;

namespace SistemaRiesgo.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //creando el usuario
            var manager = new UserManager();
            var user = new ApplicationUser() { UserName = UserName.Text, Email = UserName.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            //si se creo exitosamente
            if (result.Succeeded)
            {
                
                //Inicio agregado usuario a rol Administrador
                Models.ApplicationDbContext context = new ApplicationDbContext();
                    //este context es la conexion por Default al SGBD de VS.
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleMgr = new RoleManager<IdentityRole>(roleStore);
                result = manager.AddToRole(manager.FindByEmail(UserName.Text).Id, "admin");
                //Fin agregado

                IdentityHelper.SignIn(manager, user, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}