using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc.Razor;

namespace MVC.ViewLocation.Web.Compiler
{
    public class MySharedLocationRemapper:IViewLocationExpander
    {
        #region Implementation of IViewLocationExpander

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // do nothing
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return viewLocations.Select(f => f.Replace("/Shared/", "/MyShared/"));
        }

        #endregion
    }
}
