using System.Web.Mvc;
using System.Web.Routing;

namespace PI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Search",
               url: "Search/{id}",
               defaults: new { controller = "Home", action = "Search", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
            name: "ChangeMonth",
            url: "Destination/ChangeMonth/{id}",
            defaults: new { controller = "Destination", action = "ChangeMonth", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "Page",
             url: "Destination/Page/{id}",
             defaults: new { controller = "Destination", action = "Page", id = UrlParameter.Optional }
            );
          
            routes.MapRoute(
               name: "Check",
               url: "Destination/{id}/Check",
               defaults: new { controller = "Destination", action = "Check", id = UrlParameter.Optional }
            );
         
            routes.MapRoute(
                name: "Appreciation",
                url: "Destination/Appreciation/{id}",
                defaults: new { controller = "Destination", action = "Appreciation", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "oneDestination",
                url: "Destination/{id}",
                defaults: new { controller = "Destination", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "notFound",
                url: "NotFound",
                defaults: new { controller = "NotFound", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}