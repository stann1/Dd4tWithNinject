using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using DD4T.Mvc.Providers;
using DD4T.ContentModel.Contracts.Providers;
using DD4T.Providers.SDLTridion2013;
using DD4T.ContentModel.Factories;
using DD4T.Factories;
using DD4T.Mvc.Html;
using DD4T.Mvc.Controllers;

namespace DD4T.Web.Mvc.Ninject
{
    public class Dd4TNinjectModule : NinjectModule
    {
        private int _publicationId;
 
        public Dd4TNinjectModule(int publicationId)
        {
            _publicationId = publicationId;
        }
 
        public override void Load()
        {
            Bind<IPageProvider>().ToMethod(context => new TridionPageProvider() { PublicationId = _publicationId });
            Bind<ILinkProvider>().To<TridionLinkProvider>();
 
            Bind<IPageFactory>().ToMethod(context => new PageFactory()
                {
                    PageProvider = context.Kernel.Get<IPageProvider>(),
                    ComponentFactory = context.Kernel.Get<IComponentFactory>(),
                    LinkFactory = context.Kernel.Get<ILinkFactory>()
                });
 
            Bind<ILinkFactory>().ToMethod(context => new LinkFactory()
                {
                   LinkProvider = context.Kernel.Get<ILinkProvider>()
                });
            
            Bind<PageController>().ToMethod(context => new PageController()
                {
                    PageFactory = context.Kernel.Get<IPageFactory>(),
                    ComponentPresentationRenderer = context.Kernel.Get<IComponentPresentationRenderer>()
                });
 
            Bind<IComponentController>().ToMethod(context => new ComponentController() { ComponentFactory = context.Kernel.Get<IComponentFactory>() });
 
            Bind<IComponentProvider>().To<TridionComponentProvider>().InSingletonScope();
            Bind<IComponentFactory>().To<ComponentFactory>().InSingletonScope();
            Bind<IComponentPresentationRenderer>().To<DefaultComponentPresentationRenderer>().InSingletonScope();
        }
    }
}
