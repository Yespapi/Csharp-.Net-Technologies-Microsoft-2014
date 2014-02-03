using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lesson03
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // www.example.com/2011/04/05
            // www.example.com/products/cookies/oreo

            routes.MapRoute(
                name: "DateRoute",
                url: "{year}/{month}/{day}",
                defaults: new
                {
                    controller = "Blog",
                    action = "Index"
                },
                constraints: new { year = @"\d{4}", month = @"\d{2}", day = @"\d{2}" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", 
                    id = UrlParameter.Optional }
            );
        }
    }
}