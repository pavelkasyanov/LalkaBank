
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
    
public partial class CreditType
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public CreditType()
    {

        this.Credits = new HashSet<Credit>();

        this.Requests = new HashSet<Request>();

    }


    public System.Guid Id { get; set; }

    public double Percent { get; set; }

    public double StartSumPercent { get; set; }

    public int PayCount { get; set; }

    public string Info { get; set; }

    public string Name { get; set; }

    public System.DateTime Created { get; set; }

    public bool Active { get; set; }

    public System.Guid CreditSubTypeId { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Credit> Credits { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Request> Requests { get; set; }

    public virtual CreditSubType CreditSubType { get; set; }

}

}
