
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
    
public partial class CreditHistory
{

    public System.Guid Id { get; set; }

    public int Month { get; set; }

    public decimal CreditBalance { get; set; }

    public decimal MainPayment { get; set; }

    public decimal Percent { get; set; }

    public decimal TotalPayment { get; set; }

    public decimal Paid { get; set; }

    public System.Guid CreditId { get; set; }

    public decimal Arrears { get; set; }

    public decimal Fine { get; set; }

    public decimal FinePayment { get; set; }



    public virtual Credit Credits { get; set; }

}

}