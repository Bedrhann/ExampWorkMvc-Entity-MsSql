//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetMVC1.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLMARKA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLMARKA()
        {
            this.TBLPRODUCT = new HashSet<TBLPRODUCT>();
        }
    
        public int MARKALARID { get; set; }

        
        [Required (ErrorMessage ="MARKA ADINI G�R�N�Z !")]
        public string MARKAAD { get; set; }
        public Nullable<int> TOPTANCI { get; set; }
    
        public virtual TBLTOPTANCI TBLTOPTANCI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLPRODUCT> TBLPRODUCT { get; set; }
    }
}
