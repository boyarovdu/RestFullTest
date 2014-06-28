using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using System.Web.Routing;
using Rest.Model.Abstract;
using Rest.Model.Concrete;


namespace SportsStore.Infrastructure
{
    public class ControllerFactory : DefaultControllerFactory
    {
        StandardKernel kernel = new StandardKernel();

        public ControllerFactory()
        {
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }

        private void AddBindings()
        {
            kernel.Bind<IUserRepository>().To<UserRepository>();
        }
    }
}