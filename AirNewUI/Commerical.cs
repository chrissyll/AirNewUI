//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
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
