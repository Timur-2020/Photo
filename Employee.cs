//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Photo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int idEmployee { get; set; }
        public string empName { get; set; }
        public string empSurname { get; set; }
        public string empMiddleName { get; set; }
        public System.DateTime empDateOfBirth { get; set; }
        public int empidPosition { get; set; }
        public string empPhoneNumber { get; set; }
        public string empLogin { get; set; }
        public string empPassword { get; set; }
    
        public virtual Position Position { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
