﻿using MobileOpsPilotData.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOpsPilotData.Service
{
    public class FlightPlanService:IFlightPlanService
    {
        public List<FlightPlan>GetFlightPlans()
        {
            return new List<FlightPlan>(); 
        }
    }
}
