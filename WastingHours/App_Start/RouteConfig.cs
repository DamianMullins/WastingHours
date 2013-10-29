using System.Web.Mvc;
using System.Web.Routing;

namespace WastingHours
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "About",
                url: "about",
                defaults: new { controller = "Home", action = "About" }
            );

            routes.MapRoute(
                name: "Contact",
                url: "contact",
                defaults: new { controller = "Home", action = "Contact" }
            );

            routes.MapRoute(
                name: "Post",
                url: "{title}",
                defaults: new { controller = "Home", action = "Post" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
