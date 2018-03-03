using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootstrapSite.Startup))]
namespace BootstrapSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
