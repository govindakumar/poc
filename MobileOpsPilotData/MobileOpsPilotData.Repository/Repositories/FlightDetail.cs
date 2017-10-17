//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileOpsPilotData.Repository.Repositories
{
    using System;
    using System.Collections.Generic;
    
    public partial class FlightDetail
    {
        public System.Guid Id { get; set; }
        public System.Guid FlightPlanId { get; set; }
        public Nullable<System.TimeSpan> ScheduledEstTimeArrival { get; set; }
        public Nullable<System.TimeSpan> ScheduledEstTimeDeparture { get; set; }
        public Nullable<System.TimeSpan> EstimatedTimeArrival { get; set; }
        public Nullable<System.TimeSpan> EstimatedTimeDeparture { get; set; }
        public string FlightNumber { get; set; }
        public string IataAirlineCode { get; set; }
        public string AtcClearance { get; set; }
        public string VersionHash { get; set; }
    
        public virtual FlightPlan FlightPlan { get; set; }
    }
}
