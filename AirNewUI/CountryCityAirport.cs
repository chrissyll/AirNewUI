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
    
    public partial class CountryCityAirport
    {
        public int Country_City_Airport_ID { get; set; }
        public Nullable<int> Country_ID { get; set; }
        public Nullable<int> City_ID { get; set; }
        public Nullable<int> Airport_ID { get; set; }
    
        public virtual Airport Airport { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
    }
}
