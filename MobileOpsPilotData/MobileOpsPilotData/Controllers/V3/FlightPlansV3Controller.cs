using Microsoft.Web.Http;
using MobileOpsPilotData.Service;
using MobileOpsPilotData.Service.Models;
//using MobileOpsPilotData.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
//using MobileOpsPilotData.Repository.Repositories;
using System.Web.OData.Routing;

namespace MobileOpsPilotData.Controllers.V3
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
        public IHttpActionResult GetFlightPlans()
        {
            var flightPlans = _flightPlanService.GetFlightPlans();
            //var flp = new List<FlightPlan>();
            return Ok<IEnumerable<FlightPlan>>(flightPlans);
           
        }

       // [EnableQuery]
       // [HttpGet]
       //// [ODataRoute("(FlightNumber={flightNumber}, IataAirlineCode={iataAirlineCode})")]
       // public IHttpActionResult GetFlightPlan([FromODataUri] string key)
       // {
       //     //return Ok < IEnumerable<new List<FlightPlan>()>;
       //     var flp = new List<FlightPlan>();
       //     return Ok<IEnumerable<FlightPlan>>(flp);
       //     // return Ok<IEnumerable<Repository.Repositories.FlightPlan>>(new List<Repository.Repositories.FlightPlan>());

       // }

        //[EnableQuery]
        //public Repository.Repositories.FlightPlan GetFlightPlan([FromODataUri] string key)
        //{
        //    var flightPlans = _flightPlanService.GetFlightPlans().Where(x=>x.FlightNumber==key).FirstOrDefault();
        //    //return Ok<IEnumerable<FlightPlan>>(flightPlans);
        //    return flightPlans;
        //}

        //[HttpGet]
        //[EnableQuery]
        ////[ODataRout("Current()")]
        //public FlightPlan Current([FromODataUri] string flightNumber, [FromODataUri] string iataAirlineCode)
        //{
        //    return new FlightPlan { FlightNumber = "kfhd" };
        //}   
        
        [ODataRoute("GetCurrentFlightPlan(flightNumber={flightNumber},iataAirlineCode={iataAirlineCode})")]
        public FlightPlan GetCurrentFlightPlan([FromODataUri] string flightNumber, [FromODataUri] string iataAirlineCode)
        {
            return new FlightPlan { FlightNumber = "kfhd" };
        }

    }
}
