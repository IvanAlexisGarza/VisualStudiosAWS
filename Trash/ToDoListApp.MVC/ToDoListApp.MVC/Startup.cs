using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToDoListApp.MVC.Startup))]
namespace ToDoListApp.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
