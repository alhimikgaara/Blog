using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Blog.Common.Constants;
using Newtonsoft.Json;

namespace Blog.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = ControllerNames.HomeShort, action = ActionNames.Index
                }
            );

            
        }
    }
}
