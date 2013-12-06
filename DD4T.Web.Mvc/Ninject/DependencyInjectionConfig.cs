using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using DD4T.Web.Mvc.Ninject;
using Ninject;
using Ninject.Modules;
using System.Web.Mvc;


namespace DD4T.Web.Mvc.Ninject
{
    public class DependencyInjectionConfig
    {
        public static void SetupDependencyResolver()
        {
            int publicationId = 0;
            if (!int.TryParse(ConfigurationManager.AppSettings["DD4T.PublicationId"], out publicationId))
            {
                throw new ConfigurationErrorsException("The AppSetting DD4T.PublicationId must have an integer value");
            }

            var kernel = new StandardKernel(new Dd4TNinjectModule(publicationId));

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}