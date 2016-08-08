using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC4.PROJECT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // chi tiết tin tức
            routes.MapRoute(
                name: "News_Detail",
                url: "{categoryname}/{title}/{id}",
                defaults: new { controller = "News", action = "NewsDetail", categoryname = UrlParameter.Optional, title = UrlParameter.Optional, id = UrlParameter.Optional },
                constraints: new { id = @"\d+", },
                namespaces: new[] { "MVC4.PROJECT.Controllers" }
                );
            // tin tức
            routes.MapRoute(
                name: "News_List",
                url: "muc-{title}",
                defaults: new { controller = "News", action = "Index", title = UrlParameter.Optional },
                //constraints: new { id = @"\d+", },
                namespaces: new[] { "MVC4.PROJECT.Controllers" }
                );
            routes.MapRoute(
               name: "Contact",
               url: "lien-he",
               defaults: new { controller = "Contact", action = "Index", title = UrlParameter.Optional },
               //constraints: new { id = @"\d+", },
               namespaces: new[] { "MVC4.PROJECT.Controllers" }
               );
            //dang ky
            routes.MapRoute(
                name: "Account",
                url: "dang-ky",
                defaults: new { controller = "Account", action = "Login"},
                //constraints: new { id = @"\d+", },
                namespaces: new[] { "MVC4.PROJECT.Controllers" }
            );
            routes.MapRoute(
               name: "Login/Register",
               url: "dang-nhap",
               defaults: new { controller = "Account", action = "Login" },
               //constraints: new { id = @"\d+", },
               namespaces: new[] { "MVC4.PROJECT.Controllers" }
           );
            // bài viết
            routes.MapRoute(
                name: "Article_List",
                url: "bai-viet/{title}",
                defaults: new { controller = "Article", action = "Index", title = UrlParameter.Optional },
                //constraints: new { id = @"\d+", },
                namespaces: new[] { "MVC4.PROJECT.Controllers" }
                );
            
         

          
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MVC4.PROJECT.Controllers" }
            );
        }
    }
}