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
    
    public partial class RequestSet
    {
        public System.Guid RequestId { get; set; }
        public string CreditInfo { get; set; }
        public byte[] PassportImage { get; set; }
        public byte[] IncomeImage { get; set; }
        public System.Guid PersonPersonId { get; set; }
        public System.Guid ManagerManagerId { get; set; }
    
        public virtual ManagerSet ManagerSet { get; set; }
        public virtual PersonSet PersonSet { get; set; }
    }
}
