using System.Collections.Generic;
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

            var generalList = new Dictionary<string, List<string>>();

            var actionsList = new List<string>()
            {
                ActionNames.Contact,
                ActionNames.Index
            };

            generalList[ControllerNames.HomeFull] = actionsList;


            var actionsListOneMore = new List<string>()
            {
                ActionNames.Index
            };
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{list}",
                defaults: new { controller = ControllerNames.WebsiteShort, action = ActionNames.Build,
                    list = generalList
                }
            );
        }
    }
}
