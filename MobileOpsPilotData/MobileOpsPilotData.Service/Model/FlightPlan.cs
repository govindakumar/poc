using MobileOpsPilotData.Service.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace MobileOpsPilotData.Service.Models
{
    public class FlightPlan
    {
        
        public int Id { get; set; }

        public Guid FlightPlanId { get; set; }

        public int SourceId { get; set; }
        [Key]
        public string FlightNumber { get; set; }
        //[Key]
        public string IataAirlineCode { get; set; }

        public DateTime DepartureDate { get; set; }

        public string Dispatcher { get; set; }

        public string DispatchDesk { get; set; }

        public string DispatchPhone { get; set; }

        public virtual FlightDetail FlightDetail { get; set; }
    }
}


