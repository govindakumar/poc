using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Data.OData;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using Microsoft.Web.Http;
using MobileOpsPilotData.Service.Interfaces;
using MobileOpsPilotData.Service.Services;
using MobileOpsPilotData.Service.Models;//using System.Web.Http.OData;

namespace MobileOpsPilotData.Controllers
{
    public class FlightPlansController : ODataController
    {
        private IFlightPlanService _flightPlanService;
        public FlightPlansController()
        {
            //_flightPlanService = flightPlanService;
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
