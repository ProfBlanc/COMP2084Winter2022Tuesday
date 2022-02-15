namespace COMP2084Winter2022Tuesday.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Prof
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prof()
        {
            Semesters = new HashSet<Semester>();
        }

        public int ProfID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Professor Name")]
        public string ProfName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Semester> Semesters { get; set; }
    }
}
