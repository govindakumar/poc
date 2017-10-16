using Microsoft.Web.OData.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData.Builder;
using Microsoft.Web.Http;
using MobileOpsPilotData.Service.Model;

namespace MobileOpsPilotData.Configuration
{
    public class FlightDetailsConfiguration : IModelConfiguration
    {
        private void ConfigureV3(ODataModelBuilder builder)
        {
            var FlightDetails = ConfigureCurrent(builder);
        }

       // private void ConfigureV2(ODataModelBuilder builder) => ConfigureCurrent(builder);

        private EntityTypeConfiguration<FlightDetail> ConfigureCurrent(ODataModelBuilder builder)
        {
            var FlightDetails = builder.EntitySet<FlightDetail>("FlightDetails").EntityType;

            //FlightDetails.HasKey(f => f.Id);

            return FlightDetails;
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