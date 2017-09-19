using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OData.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Microsoft.Practices.Unity;
using OData.Logging;
using OData.Controllers;

namespace OData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //RegisterDependency;
            var container = new UnityContainer();
            container.RegisterType<ILogMessage, DBLogging>(new HierarchicalLifetimeManager());
            //container.regis
            config.DependencyResolver = new UnityResolver(container);
           

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Product>("Products");
            builder.EntitySet<Supplier>("Suppliers");
            builder.EntitySet<Log>("Logs");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
            //Action
            builder.Namespace = "OData";
            builder.EntityType<Product>()
                 .Action("Rate")
                 .Parameter<int>("Rating");
            //Function
           // builder.Namespace = "OData";
            builder.EntityType<Product>().Collection
                   .Function("MostExpensive")
                   .Returns<double>();

            //Unbound Function
            //builder.Function("GetSalesTaxRate")
            //       .Returns<double>()
            //       .Parameter<int>("PostalCode");
            config.Select().Expand().Filter().OrderBy().MaxTop(null).Count();
        }

    }
}
