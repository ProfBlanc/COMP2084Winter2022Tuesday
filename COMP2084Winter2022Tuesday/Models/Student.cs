namespace COMP2084Winter2022Tuesday.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Semesters = new HashSet<Semester>();
        }

        //add three different restrictions for the Students Model
        //min length, max length 
        //add custom error messaged

        public int StudentID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Student First Name")]
        [MinLength(3, ErrorMessage = "First Name needs to be at least 3 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Student Last Name")]
        public string LastName { get; set; }

        public int SchoolAttending { get; set; }

        public virtual School School { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Semester> Semesters { get; set; }
    }
}
