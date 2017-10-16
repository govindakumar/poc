using MobileOpsPilotData.Service;
using MobileOpsPilotData.Service.Models;
using System.Linq;
using System.Web.OData;

namespace MobileOpsPilotData.Controllers
{
    public class FlightPlansController : ODataController
    {
        private IFlightPlanService _flightPlanService;
        public FlightPlansController(IFlightPlanService flightPlanService)
        {
            _flightPlanService = flightPlanService;
        }

        //[System.Web.Http.OData.EnableQuery]
        public IQueryable<FlightPlan> GetFlightPlans()
        {
            var flightPlans = _flightPlanService.GetFlightPlans();
            //return Ok<IEnumerable<FlightPlan>>(flightPlans);
            return (IQueryable<FlightPlan>)(flightPlans);


        }
    }
}
