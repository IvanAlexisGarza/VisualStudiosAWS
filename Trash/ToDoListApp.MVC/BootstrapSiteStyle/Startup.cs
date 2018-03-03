using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootstrapSiteStyle.Startup))]
namespace BootstrapSiteStyle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
