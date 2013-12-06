using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DD4T.Mvc.Controllers;
using System.Web.Mvc;
using DD4T.ContentModel;
using DD4T.ContentModel.Exceptions;
using Yabolka.CMS.Tridion.DD4T.ViewModels.Infrastructure;
using DD4T.Web.Mvc.Helper;
using System.Web.Optimization;


namespace DD4T.Web.Mvc
{
    public class ComponentController : TridionControllerBase
    {
        //protected override ViewResult GetView(IComponentPresentation componentPresentation)
        //{
        //    // TODO: define field names in Web.config
        //    if (!componentPresentation.ComponentTemplate.MetadataFields.ContainsKey("view"))
        //    {
        //        throw new ConfigurationException("no view configured for component template " + componentPresentation.ComponentTemplate.Id);
        //    }

        //    string viewName = componentPresentation.ComponentTemplate.MetadataFields["view"].Value;

        //    var model = ViewModelBuilder.Build(componentPresentation);

        //    //if (model != null)
        //    //   return View(viewName, model);

        //    //return View(viewName, componentPresentation);

        //    if (model != null)
        //        return View("NewArticle", model);

        //    return View("OldArticle", componentPresentation);
        //}

        protected override ViewResult GetView(IComponentPresentation componentPresentation)
        {
            if (!componentPresentation.ComponentTemplate.MetadataFields.ContainsKey("view"))
            {
                throw new ConfigurationException("no view configured for component template " + componentPresentation.ComponentTemplate.Id);
            }
            string viewName = componentPresentation.ComponentTemplate.MetadataFields["view"].Value;
            return View(viewName, componentPresentation.Component);
        }

        private object GetModel()
        {
            return this.RouteData.Values["model"];
        }
    }
}
