//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagerDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProject()
        {
            this.tblTasks = new HashSet<tblTask>();
        }
    
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public Nullable<System.DateTime> PStartDate { get; set; }
        public Nullable<System.DateTime> PEndDate { get; set; }
        public Nullable<int> PPriority { get; set; }
        public Nullable<int> ManagerId { get; set; }
        public Nullable<int> Nooftasks { get; set; }
        public Nullable<int> completed { get; set; }
        public Nullable<bool> Pstatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTask> tblTasks { get; set; }
    }
}
