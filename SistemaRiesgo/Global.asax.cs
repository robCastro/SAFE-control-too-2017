using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using SistemaRiesgo.Models;
using SistemaRiesgo.Logica;

namespace SistemaRiesgo
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //inicializando la BD
            //Database.SetInitializer(new Inicializador());

            //crear un rol y usuario
            AccionesRol rol = new AccionesRol();
            rol.AddUserAndRole();
        }
    }
}