﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class LalkaBankDabaseModelContainer : DbContext
{
    public LalkaBankDabaseModelContainer()
        : base("name=LalkaBankDabaseModelContainer")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<BankBook> BankBooks { get; set; }

    public virtual DbSet<Credit> Credits { get; set; }

    public virtual DbSet<CreditType> CreditTypes { get; set; }

    public virtual DbSet<Debts> Debts { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Passport> Passports { get; set; }

    public virtual DbSet<Payments> Payments { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

    public virtual DbSet<BankAaccount> BankAaccount { get; set; }

    public virtual DbSet<CreditHistory> CreditHistory { get; set; }

    public virtual DbSet<Table> Table { get; set; }

    public virtual DbSet<CreditSubType> CreditSubType { get; set; }

}

}

