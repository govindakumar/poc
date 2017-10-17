using MobileOpsPilotData.Repository.Interfaces;
using MobileOpsPilotData.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOpsPilotData.Service
{
    public class FlightPlanService:IFlightPlanService
    {
        private IFlightPlanRepository _flightPlanRepository;
        public FlightPlanService(IFlightPlanRepository flightPlanRepository)
        {
            _flightPlanRepository = flightPlanRepository;
        }
        public IQueryable<FlightPlan> GetFlightPlans()
        {
           var data= _flightPlanRepository.GetFlightPlans();
            
            return data;

        }
    }
}
