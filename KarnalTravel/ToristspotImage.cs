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
    
    public partial class ToristspotImage
    {
        public int Id { get; set; }
        public string imgurl { get; set; }
        public Nullable<int> Touristspotid { get; set; }
    
        public virtual TouristSpot TouristSpot { get; set; }
    }
}
