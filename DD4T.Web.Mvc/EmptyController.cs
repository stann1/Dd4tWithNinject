using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace DD4T.Web.Mvc
{
    public class EmptyController : Controller
    {
        /// <summary>
        /// This action retuns an emtpy result to prevent SDL Tridion UI 2011 from throwing 404's
        /// </summary>
        /// <returns>Empty result</returns>
        public ActionResult Index()
        {
            return new EmptyResult();
        }
    }
}
