
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
    
public partial class Commerical
{

    public int Commerical_ID { get; set; }

    public Nullable<int> Airport_ID { get; set; }

    public byte[] Photo { get; set; }

    public Nullable<System.DateTime> On_Sale { get; set; }



    public virtual Airport Airport { get; set; }

}

}
