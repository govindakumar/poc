using System;

namespace MobileOpsPilotData.Service.Models
{
    public class FlightPlan
    {
        public int Id { get; set; }

        public Guid FlightPlanId { get; set; }

        public int SourceId { get; set; }

        public string FlightNumber { get; set; }

        public string IataAirlineCode { get; set; }

        public DateTime DepartureDate { get; set; }

        public string Dispatcher { get; set; }

        public string DispatchDesk { get; set; }

        public string DispatchPhone { get; set; }
    }
}


