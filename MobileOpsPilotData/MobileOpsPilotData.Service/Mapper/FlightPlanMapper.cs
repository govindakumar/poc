using MobileOpsPilotData.Service.Models;
//using MobileOpsPilotData.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOpsPilotData.Service.Mapper
{
    public class FlightPlanMapper:IFlightPlanMapper
    {
        private IFlightPlanMapper _flightPlanMapper;
        public FlightPlanMapper(IFlightPlanMapper flightPlanMapper)
        {
            _flightPlanMapper = flightPlanMapper;
        }

        //public FlightPlan Map(Repository.Repositories.FlightPlan)
        //{

        //}
    }
}
