[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MovieShop.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MovieShop.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace MovieShop.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using MovieShop.Data.Repositories;
    using MovieShop.Service;
    using Ninject;
    using Ninject.Web.Common;

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
            //this method provides us the way to imject implementation for interfaces in our project
            //this is one place where you can easily replace implementations
            kernel.Bind<IMovieService>().To<MovieService>();
            kernel.Bind<IGenreService>().To<GenreService>();
            kernel.Bind<ICastService>().To<CastService>();
            kernel.Bind<IMovieRepository>().To<MovieRepository>();
            kernel.Bind<IGenreRepository>().To<GenreRepository>();
            kernel.Bind<ICastRepository>().To<CastRepository>();
            //when you add any new injectionsm make sure you add your binding/registration here
        }        
    }
}
