using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Blog.Common.Constants;

namespace Blog.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{list}",
                defaults: new { controller = ControllerNames.WebsiteShort, action = ActionNames.Build,
                    list = new Dictionary<string, List<string>>
                    {
                        { ControllerNames.HomeFull, new List<string>
                        {
                            ActionNames.Index,
                            ActionNames.About
                        }}
                    }
                }
            );
        }
    }
}
