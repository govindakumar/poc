using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileOpsPilotData.Service.Model
{
    public class FlightDetail
    {
        [Key]
        public int id { get; set; }
        public Aerodrome Arrival { get; set; }
        public Aerodrome Departure { get; set; }
        public DateTime ScheduledEstTimeArrival { get; set; }
        public DateTime ScheduledEstTimeDeparture { get; set; }
        public DateTime EstimatedTimeArrival { get; set; }
        public DateTime EstimatedTimeDeparture { get; set; }
        public string FlightNumber { get; set; }
        public string IataAirlineCode { get; set; }
        public string AtcClearance { get; set; }

    }
}
