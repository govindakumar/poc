using MobileOpsPilotData.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOpsPilotData.Repository.Repositories
{
    public class FlightPlanRepository: IFlightPlanRepository
    {
        private MobileOpsPilotDb _ctx;
        public FlightPlanRepository(MobileOpsPilotDb ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<FlightPlan> GetFlightPlans()
        {
            //using (_ctx)
            //{
                var data = from p in _ctx.FlightPlans
                           select p;
                return data;
           // }
        }
    }
}
