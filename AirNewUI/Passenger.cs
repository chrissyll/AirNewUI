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
    
    public partial class Passenger
    {
        public int Passenger_ID { get; set; }
        public Nullable<int> Ticket_ID { get; set; }
        public string Passenger_En_FirstName { get; set; }
        public string Passenger_En_LastName { get; set; }
        public string Passenger_Gender { get; set; }
        public string Passenger_Passport { get; set; }
        public Nullable<System.DateTime> Death_Of_Expiry { get; set; }
        public Nullable<System.DateTime> Death_Of_Birth { get; set; }
        public string Passenger_Type { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
