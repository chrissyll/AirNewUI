//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirNewUI
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
