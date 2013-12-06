using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DD4T.Mvc.Controllers;
using System.Web.Optimization;
using System.Web.Mvc;

namespace DD4T.Web.Mvc
{
    public class PageController : TridionControllerBase
    {
        public override System.Web.Mvc.ActionResult Page(string pageId)
        {
            return base.Page(pageId);
        }
    }
}
