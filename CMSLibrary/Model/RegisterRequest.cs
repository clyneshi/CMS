//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMSLibrary.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegisterRequest
    {
        public int Id { get; set; }
        public Nullable<int> confId { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string contact { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public Nullable<int> roleId { get; set; }
    
        public virtual Conference Conference { get; set; }
        public virtual Role Role { get; set; }
    }
}