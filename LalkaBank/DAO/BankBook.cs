//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class BankBook
    {
        public System.Guid Id { get; set; }
        public int cache { get; set; }
        public System.Guid CreditId { get; set; }
    
        public virtual Credit Credits { get; set; }
    }
}
