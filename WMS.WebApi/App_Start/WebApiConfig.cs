using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WMS.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            // config.Routes.MapHttpRoute(
            //  name: "DefaultApiWithAction",
            //  routeTemplate: "api/{controller}/{action}/{id}",
            //  defaults: new { id = RouteParameter.Optional }
            //);

             #region Workflow Mapping Routing
             config.Routes.MapHttpRoute(
             name: "GetWorkflowMapping_Classification",
             routeTemplate: "api/{controller}/{action}/{workflow}/{process}/{subProcess}/{classification}",
             defaults: new { workflow = string.Empty, process = string.Empty, subProcess = string.Empty, classification = string.Empty }
             );

             config.Routes.MapHttpRoute(
           name: "GetNotificationMapping_Status",
           routeTemplate: "api/{controller}/{action}/{workflow}/{process}/{subProcess}/{classification}/{status}",
           defaults: new { workflow = string.Empty, process = string.Empty, subProcess = string.Empty, classification = string.Empty, status = string.Empty }
           );

              config.Routes.MapHttpRoute(
              name: "GetWorkflowMapping_Level",
              routeTemplate: "api/{controller}/{action}/{workflow}/{process}/{subProcess}/{classification}/{level}",
              defaults: new { workflow = string.Empty, process = string.Empty, subProcess = string.Empty, classification = string.Empty, level = 0 }
              );

           

              config.Routes.MapHttpRoute(
              name: "GetWorkflowMapping_Roles",
              routeTemplate: "api/{controller}/{action}/{workflow}/{process}/{subProcess}/{classification}/{level}/{roles}",
              defaults: new { workflow = string.Empty, process = string.Empty, subProcess = string.Empty, classification = string.Empty, level = 0, roles = string.Empty }
              );
             #endregion
             

            config.EnableSystemDiagnosticsTracing();

            //format json
            var jsonformatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonformatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
