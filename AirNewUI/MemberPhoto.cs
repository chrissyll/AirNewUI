
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
    
public partial class MemberPhoto
{

    public int MemberPhoto_ID { get; set; }

    public byte[] MemberPhoto1 { get; set; }

    public Nullable<int> MemberViewDetail_ID { get; set; }



    public virtual MemberViewDetail MemberViewDetail { get; set; }

}

}
