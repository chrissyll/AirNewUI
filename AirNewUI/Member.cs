
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
    
public partial class Member
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Member()
    {

        this.MemberViewDetails = new HashSet<MemberViewDetail>();

    }


    public int Member_ID { get; set; }

    public string Member_Account { get; set; }

    public string Member_Password { get; set; }

    public string Member_Ch_FirstName { get; set; }

    public string Member_Ch_LastName { get; set; }

    public string Member_En_FirstName { get; set; }

    public string Member_En_LastName { get; set; }

    public string Member_Gender { get; set; }

    public Nullable<System.DateTime> Date_Of_Birth { get; set; }

    public string Member_Phone { get; set; }

    public Nullable<int> Country_ID { get; set; }



    public virtual Country Country { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<MemberViewDetail> MemberViewDetails { get; set; }

}

}
