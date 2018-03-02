using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Http;
using Softtek.Academy2018.ToDoListApp.Data.Contracts;
using Softtek.Academy2018.ToDoListApp.Data.Implementations;
using Softtek.Academy2018.ToDoListApp.Business.Contracts;
using Softtek.Academy2018.ToDoListApp.Business.Implementations;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Softtek.Academy2018.ToDoListApp.WebAPI.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Softtek.Academy2018.ToDoListApp.WebAPI.NinjectWebCommon), "Stop")]
namespace Softtek.Academy2018.ToDoListApp.WebAPI
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Rebind<HttpConfiguration>().ToMethod(
                context => GlobalConfiguration.Configuration);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch (Exception)
            {
                kernel.Dispose();
                throw;
            }
        }
        private static void RegisterServices(StandardKernel kernel)
        {
            kernel.Bind<IItemRepo>().To<ItemRepo>();
            kernel.Bind<ITagRepo>().To<TagRepo>();

            kernel.Bind<IItemService>().To<ItemService>();
            kernel.Bind<ItagService>().To<TagService>();
        }
    }
}