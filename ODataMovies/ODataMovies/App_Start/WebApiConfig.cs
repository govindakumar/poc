using Microsoft.OData.Edm;
using ODataMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ODataMovies
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //This is one way of registring the OData route.
            //ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
            //modelBuilder.EntitySet<Movie>("Movies");
            //config.MapODataServiceRoute("Movies", "odata", modelBuilder.GetEdmModel());

            //ODataConventionModelBuilder modelBuilder1 = new ODataConventionModelBuilder();
            //modelBuilder1.EntitySet<Employee>("Employees");
            //config.MapODataServiceRoute("Employees", "odata", modelBuilder1.GetEdmModel());

            config.MapODataServiceRoute("odata", null, GetEdmModel(), new System.Web.OData.Batch.DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();

            /* Old Stuff
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            */
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "Demos";
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<Movie>("Movies");
            builder.EntitySet<Employee>("Employees");
            builder.EntitySet<MovieExpenses>("");
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }

    }
}
