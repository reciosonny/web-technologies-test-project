//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework.Domain.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public Nullable<int> PersonId { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
