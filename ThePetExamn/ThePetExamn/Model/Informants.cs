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
    
    public partial class Informants
    {
        public int ID { get; set; }
        public Nullable<int> GangID { get; set; }
        public Nullable<int> AgentID { get; set; }
        public System.DateTime Deployment { get; set; }
        public System.DateTime EndOfDeployment { get; set; }
    
        public virtual Agents Agents { get; set; }
        public virtual Gangs Gangs { get; set; }
    }
}