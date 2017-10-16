using Microsoft.Web.Http;
using MobileOpsPilotData.Service;
using MobileOpsPilotData.Service.Model;
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
    //[ODataRoutePrefix("FlightPlans")]
    public class FlightPlansV3Controller : ODataController
    {
        private IFlightPlanService _flightPlanService;
        public FlightPlansV3Controller(IFlightPlanService flightPlanService)
        {
            _flightPlanService = flightPlanService;
        }

        [EnableQuery]
        public IQueryable<FlightPlan> GetFlightPlans()
        {
            var flightPlans = _flightPlanService.GetFlightPlans();
            //return Ok<IEnumerable<FlightPlan>>(flightPlans);
            return (IQueryable<FlightPlan>)(flightPlans);


        }

        [EnableQuery]
        public FlightPlan GetFlightPlan([FromODataUri] string key)
        {
            var flightPlans = _flightPlanService.GetFlightPlans().FirstOrDefault();
            //return Ok<IEnumerable<FlightPlan>>(flightPlans);
            return flightPlans;
        }

        [HttpGet]
        [EnableQuery]
        public FlightPlan Current([FromODataUri] string key)
        {
            return new FlightPlan{ FlightNumber = "kfhd" };
        }      

    }
}
