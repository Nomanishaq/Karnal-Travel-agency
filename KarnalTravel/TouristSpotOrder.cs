//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KarnalTravel
{
    using System;
    using System.Collections.Generic;
    
    public partial class TouristSpotOrder
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> TouristSpotsId { get; set; }
        public int Person { get; set; }
        public Nullable<int> Amount { get; set; }
    
        public virtual User User { get; set; }
        public virtual TouristSpot TouristSpot { get; set; }
    }
}
