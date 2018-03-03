using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Softtek.Academy2018.ToDoListApp.Web.Startup))]
namespace Softtek.Academy2018.ToDoListApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
