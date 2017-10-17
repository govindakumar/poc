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
    
    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            this.FlightPlans = new HashSet<FlightPlan>();
        }
    
        public System.Guid Id { get; set; }
        public string FlightNumber { get; set; }
        public string IataAirlineCode { get; set; }
        public Nullable<System.DateTime> DepartureDate_ { get; set; }
        public string VersionHash_ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FlightPlan> FlightPlans { get; set; }
    }
}
