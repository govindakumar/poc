using MobileOpsPilotData.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOpsPilotData.Repository.Interfaces
{
    public interface IFlightPlanRepository
    {
        IQueryable<FlightPlan> GetFlightPlans();
    }
}
