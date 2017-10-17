using Microsoft.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.UriParser;
using Microsoft.Web.Http;
using Microsoft.Web.Http.Versioning;
using Microsoft.Web.OData.Builder;
using MobileOpsPilotData.Configuration;
using MobileOpsPilotData.Extensions;
using MobileOpsPilotData.Service.Model;
using MobileOpsPilotData.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Batch;
//using System.Web.Http.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Routing;
using System.Web.OData.Routing.Conventions;
//using System.Web.Http.OData.Builder;

namespace MobileOpsPilotData
{
    public static class WebApiConfig
    {
        static void ConfigureODataServices(IContainerBuilder builder)
        {
            builder.AddService(Microsoft.OData.ServiceLifetime.Singleton, typeof(ODataUriResolver), sp => new CaseInsensitiveODataUriResolver());
        }
        public static void Register(HttpConfiguration config)
        {
            
            config.MapHttpAttributeRoutes();
            var httpServer = new HttpServer(config);
            config.AddApiVersioning();
            config.Select().Expand().Filter().OrderBy().MaxTop(null).Count();
           
            var modelBuilder = new VersionedODataModelBuilder(config)
            {
                ModelBuilderFactory = () => new ODataConventionModelBuilder().EnableLowerCamelCase(),
                ModelConfigurations =
                {
                    new FlightPlanConfiguration(),
                    new FlightDetailsConfiguration()

                }

            };
            var models = modelBuilder.GetEdmModels();
            var batchHandler = new DefaultODataBatchHandler(httpServer);
            var conventions = ODataRoutingConventions.CreateDefault();
            conventions.Insert(0, new CompositeKeyRoutingConvention());

            config.MapVersionedODataRoutes("odata", "data/v{apiVersion}", models, ConfigureODataServices, batchHandler);
            //config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            //config.MapVersionedODataRoutes("odata", "data/v{apiVersion}", models, new DefaultODataPathHandler(),conventions, batchHandler);


        }
    }
}
