
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
    
public partial class View
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public View()
    {

        this.MemberViewDetails = new HashSet<MemberViewDetail>();

        this.ViewPhotoes = new HashSet<ViewPhoto>();

    }


    public int View_ID { get; set; }

    public string View_Name { get; set; }

    public string View_Type { get; set; }

    public Nullable<int> Area_ID { get; set; }

    public string View_Desc { get; set; }



    public virtual Area Area { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<MemberViewDetail> MemberViewDetails { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ViewPhoto> ViewPhotoes { get; set; }

}

}
