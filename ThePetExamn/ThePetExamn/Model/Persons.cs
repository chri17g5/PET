//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThePetExamn.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Persons
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string PersonalAddress { get; set; }
        public string HeadShot { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> AgentID { get; set; }
        public Nullable<int> GangsID { get; set; }
    
        public virtual Agents Agents { get; set; }
        public virtual Gangs Gangs { get; set; }
    }
}
