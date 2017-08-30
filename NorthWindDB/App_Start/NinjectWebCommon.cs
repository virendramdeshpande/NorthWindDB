[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NorthWindDB.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NorthWindDB.App_Start.NinjectWebCommon), "Stop")]

namespace NorthWindDB.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using CQRSFrameWork;
    using Repositories;
    using Ninject.Web.WebApi;
    using System.Web.Http;

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
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

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

            kernel.Bind(x => x
           .FromAssembliesMatching("Repositories.dll")
           .SelectAllClasses().EndingWith("Repository")
           .BindDefaultInterfaces());

            //kernel.Bind(x => x
            //    .FromAssembliesMatching("Repositories.dll")
            //    .SelectAllClasses().InheritedFrom(typeof(ICustomerRepository))
            //    .BindDefaultInterfaces());


            //kernel.Bind<ICustomerRepository>().To<CustomerRepository>();

            //kernel.Bind(x => x
            //    .FromAssembliesMatching("AT.SampleApp.Cqrs.dll", "MongoRepository.dll")
            //    .SelectAllClasses().InheritedFrom(typeof(IRepository<>))
            //    .BindAllInterfaces());

            //kernel.Bind(x => x
            //   .FromAssembliesMatching("CQRSFrameWork.dll", "QueryHandlers.dll", "NorthWindDB.dll")
            //   .SelectAllClasses()
            //   .BindDefaultInterface());

            //kernel.Bind(x => x
            // .FromAssembliesMatching("CQRSFrameWork.dll", "Commandhandlers.dll", "NorthWindDB.dll")
            // .SelectAllClasses()
            // .BindDefaultInterface());

            kernel.Bind(x => x
             .FromAssembliesMatching("CQRSFrameWork.dll", "NorthWindDB.dll")
             .SelectAllClasses()
             .BindDefaultInterface());

            kernel.Bind(x => x
                .FromAssembliesMatching("QueryHandlers.dll")
                .SelectAllClasses().InheritedFrom(typeof(IQueryHandler<,>))
                .BindAllInterfaces());

            kernel.Bind(x => x
                .FromAssembliesMatching("Commandhandlers.dll")
                .SelectAllClasses().InheritedFrom(typeof(ICommandHandler<>))
                .BindAllInterfaces());

        }        
    }
}
