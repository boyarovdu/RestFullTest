using Ninject;
using Ninject.Modules;
using Rest.Model.Abstract;
using Rest.Model.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace Rest.Infrastructure
{
    public class NinjectHttpResolver : IDependencyResolver, IDependencyScope
    {
        public IKernel Kernel { get; private set; }

        public NinjectHttpResolver(params NinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);
        }

        public NinjectHttpResolver(Assembly assembly)
        {
            Kernel = new StandardKernel();
            Kernel.Load(assembly);
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
            //Do Nothing
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }

    public class NinjectHttpModules
    {
     
        public static NinjectModule[] Modules
        {
            get
            {
                return new[] { new MainModule() };
            }
        }

        public class MainModule : NinjectModule
        {
            public override void Load()
            {
                Kernel.Bind<IUserRepository>().To<UserRepository>();
            }
        }
    }

    public class NinjectHttpContainer
    {
        private static NinjectHttpResolver _resolver;

        public static void RegisterModules(NinjectModule[] modules)
        {
            _resolver = new NinjectHttpResolver(modules);
            GlobalConfiguration.Configuration.DependencyResolver = _resolver;
        }

        public static void RegisterAssembly()
        {
            _resolver = new NinjectHttpResolver(Assembly.GetExecutingAssembly());
            GlobalConfiguration.Configuration.DependencyResolver = _resolver;
        }

        public static T Resolve<T>()
        {
            return _resolver.Kernel.Get<T>();
        }
    }
}