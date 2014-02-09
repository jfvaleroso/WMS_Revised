using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WMS.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
              name: "DefaultApi_Action",
              routeTemplate: "api/{controller}/{action}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );
            config.Routes.MapHttpRoute(
             name: "DefaultApi_Node",
             routeTemplate: "api/{controller}/{action}/{workflow}/{process}/{subProcess}/{classification}",
             defaults: new { workflow = RouteParameter.Optional, process = RouteParameter.Optional, subProcess = RouteParameter.Optional, classification = RouteParameter.Optional }
         );
        }
    }
}
