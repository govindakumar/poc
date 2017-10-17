using MobileOpsPilotData.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileOpsPilotData.Repository.Repositories;

namespace MobileOpsPilotData.Service
{
    public interface IFlightPlanService
    {
        IQueryable<Repository.Repositories.FlightPlan> GetFlightPlans();
    }
}
