
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace AirTicket
{

using System;
    using System.Collections.Generic;
    
public partial class Flight
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Flight()
    {

        this.AirplainCabinDetails = new HashSet<AirplainCabinDetail>();

        this.FlightSeats = new HashSet<FlightSeat>();

        this.Orders = new HashSet<Order>();

    }


    public int Flight_ID { get; set; }

    public Nullable<int> Airplain_ID { get; set; }

    public Nullable<System.DateTime> Departure_Date { get; set; }

    public Nullable<System.DateTime> Arrival_date { get; set; }

    public Nullable<int> Country_ID { get; set; }

    public Nullable<int> Airport_ID { get; set; }

    public Nullable<System.TimeSpan> Duration { get; set; }



    public virtual Airplain Airplain { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<AirplainCabinDetail> AirplainCabinDetails { get; set; }

    public virtual Airport Airport { get; set; }

    public virtual Country Country { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<FlightSeat> FlightSeats { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Order> Orders { get; set; }

}

}
