using Microsoft.Web.OData.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData.Builder;
using Microsoft.Web.Http;
using MobileOpsPilotData.Service.Models;
using Microsoft.OData.Edm;

namespace MobileOpsPilotData.Configuration
{
    public class FlightPlanConfiguration : IModelConfiguration
    {
        
        private void ConfigureV3(ODataModelBuilder builder) => ConfigureCurrent(builder);

        private EntityTypeConfiguration<FlightPlan> ConfigureCurrent(ODataModelBuilder builder)
        {
            //var flightplan = builder.EntitySet<FlightPlan>("FlightPlans").EntityType;
            builder.EntitySet<FlightPlan>("FlightPlans");
            var flightPlanType = builder.EntityType<FlightPlan>();
            //flightPlanType
            //   .Function("Current")
            //   .Returns<FlightPlan>()
            //   .Parameter<string>("flightNumber");
            flightPlanType
               .Function("Current")
               .ReturnsFromEntitySet<FlightPlan>("FlightPlan");

            //var fnCurrent = builder.EntityType<FlightPlan>().Collection.Function("Current");
            //fnCurrent.Parameter<string>("flightNumber");
            //fnCurrent.ReturnsFromEntitySet<FlightPlan>("FlightPlan");
            //var functionFlightPlan = builder.Function("GetFlightPlansP");
            //functionFlightPlan.Returns<FlightPlan>();
            //functionFlightPlan.Parameter<string>("flightNumber");
            //functionFlightPlan.Parameter<string>("iataCode");
            //builder.Function("GetFlightPlans")
            //    .Returns<FlightPlan>()
            //    .Parameter(<string>("flightNumber")
                

            return builder.EntityType<FlightPlan>();
           

            // return flightplan;
        }

        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
        {
            switch (apiVersion.MajorVersion)
            {
                case 3:
                    ConfigureV3(builder);
                    break;
                default:
                    ConfigureCurrent(builder);
                    break;
            }
        }
    }
}