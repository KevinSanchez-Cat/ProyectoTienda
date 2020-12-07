using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoTienda.Startup))]
namespace ProyectoTienda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
