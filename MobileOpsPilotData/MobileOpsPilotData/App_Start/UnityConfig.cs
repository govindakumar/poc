using Microsoft.Practices.Unity;
using MobileOpsPilotData.Repository.Interfaces;
using MobileOpsPilotData.Repository.Repositories;
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
            container.RegisterType<IFlightPlanRepository, FlightPlanRepository>();
            container.RegisterInstance<MobileOpsPilotDb>(new MobileOpsPilotDb());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}