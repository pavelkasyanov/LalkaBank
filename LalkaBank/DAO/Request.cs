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
    
    public partial class Request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Request()
        {
            this.Messages = new HashSet<Message>();
        }
    
        public System.Guid Id { get; set; }
        public string CreditInfo { get; set; }
        public byte[] PassportImage { get; set; }
        public byte[] IncomeImage { get; set; }
        public System.Guid PersonId { get; set; }
        public Nullable<System.Guid> ManagerId { get; set; }
        public System.Guid CreditTypeId { get; set; }
        public int Confirm { get; set; }
        public int Number { get; set; }
    
        public virtual Manager Managers { get; set; }
        public virtual Person Persons { get; set; }
        public virtual CreditType CreditTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
