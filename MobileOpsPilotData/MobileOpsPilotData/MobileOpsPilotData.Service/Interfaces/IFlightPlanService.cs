using MobileOpsPilotData.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOpsPilotData.Service.Interfaces
{
    public interface IFlightPlanService
    {
        List<FlightPlan> GetFlightPlans();
    }
}
