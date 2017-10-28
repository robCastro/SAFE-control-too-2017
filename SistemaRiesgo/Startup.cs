using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaRiesgo.Startup))]
namespace SistemaRiesgo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
