//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MBNSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientsBranch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientsBranch()
        {
            this.ClientsContacts = new HashSet<ClientsContact>();
        }
    
        public int ClientId { get; set; }
        public int BranchId { get; set; }
        public bool IsHO { get; set; }
        public int Status { get; set; }
        public string BranchNo { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string EmailId { get; set; }
        public string Remarks { get; set; }
    
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientsContact> ClientsContacts { get; set; }
        public virtual Client Client1 { get; set; }
    }
}
