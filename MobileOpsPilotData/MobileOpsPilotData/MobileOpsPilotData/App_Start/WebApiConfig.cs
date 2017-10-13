using MobileOpsPilotData.Service.Model;
using MobileOpsPilotData.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
//using System.Web.Http.OData.Builder;

namespace MobileOpsPilotData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            var entityset=builder.EntitySet<FlightPlan>("FlightPlans");
            entityset.EntityType.HasKey(x => x.Id);

            //builder.EntitySet<Aerodrome>("Aerodromes");
            //builder.EntitySet<FlightDetail>("FlightDetails");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());

           // ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
           // builder.EntitySet<FlightPlan>("FlightPlans");
           // builder.EntitySet<Aerodrome>("Aerodromes");
           // builder.EntitySet<FlightDetail>("FlightDetails");
           //// config.MapODataServiceRoute("odata", "data", builder.GetEdmModel());
           // config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
           // config.Select().Expand().Filter().OrderBy().MaxTop(null).Count();

        }
    }
}
