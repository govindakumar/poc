using Microsoft.Practices.Unity;
using MobileOpsPilotData.Service;
using System.Web.Http;
using Unity.WebApi;

namespace MobileOpsPilotData
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IFlightPlanService, FlightPlanService>();            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}