using ODataPoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ODataPoc
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<Movie>("Movies"); // We are exposing only Movies via oData
            config.MapODataServiceRoute("Movies", "odata", modelBuilder.GetEdmModel());
            // Web API configuration and services
            // Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
