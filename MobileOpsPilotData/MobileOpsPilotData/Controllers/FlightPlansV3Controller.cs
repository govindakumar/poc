using Microsoft.Web.Http;
using MobileOpsPilotData.Service.Interfaces;
using MobileOpsPilotData.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace MobileOpsPilotData.Controllers
{
    [ApiVersion("3.0")]
    [ControllerName("FlightPlans")]
    [ODataRoutePrefix("FlightPlans")]
    public class FlightPlansV3Controller : ODataController
    {
        private IFlightPlanService _flightPlanService;
        public FlightPlansV3Controller()
        {
            //_flightPlanService = flightPlanService;
        }

        //[System.Web.Http.OData.EnableQuery]
        public IQueryable<FlightPlan> Get()
        {
            var flightPlans = _flightPlanService.GetFlightPlans();
            //return Ok<IEnumerable<FlightPlan>>(flightPlans);
            return (IQueryable<FlightPlan>)(flightPlans);


        }
    }
}
