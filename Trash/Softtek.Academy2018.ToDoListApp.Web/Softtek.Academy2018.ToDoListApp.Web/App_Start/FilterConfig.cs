using System.Web;
using System.Web.Mvc;

namespace Softtek.Academy2018.ToDoListApp.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
