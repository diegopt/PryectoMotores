using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiTienda.Startup))]
namespace MiTienda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
