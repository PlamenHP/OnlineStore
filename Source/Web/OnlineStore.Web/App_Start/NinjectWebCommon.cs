[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OnlineStore.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(OnlineStore.Web.App_Start.NinjectWebCommon), "Stop")]

namespace OnlineStore.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Data.UnitOfWork;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using OnlineStore.Models;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IStoreDb>().To<StoreDb>();
            kernel.Bind<IApplicationDbContext>().To<ApplicationDbContext>();
            kernel.Bind<ApplicationDbContext>().ToSelf().InRequestScope();
            kernel.Bind(typeof(UserManager<>)).ToSelf();
            kernel.Bind(typeof(UserStore<>)).ToSelf();
            kernel.Bind(typeof(DbContext)).To(typeof(IApplicationDbContext)).InRequestScope();
            kernel.Bind(typeof(IUserStore<ApplicationUser>)).To(typeof(UserStore<ApplicationUser>)).InRequestScope();
            kernel.Bind(typeof(UserManager<ApplicationUser>)).ToSelf().InRequestScope();
        }        
    }
}
