namespace COMP2084Winter2022Tuesday.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Semester")]
    public partial class Semester
    {
        /*
         * MinLength
         * MaxLength
         * 
         */ 
        public int SemesterID { get; set; }

        [Required(ErrorMessage = "Term is a required field!")]
        [StringLength(6, ErrorMessage = "Max String Length of 6 characters")]
        [MinLength(4, ErrorMessage = "Term Too Short!")]
        public string Term { get; set; } = "benny";

        [Required]
        [Range(1900, 3000)] //set an error message if Year is not within range
        public decimal Year { get; set; }

        public int ProfID { get; set; }

        public int StudentID { get; set; }

        public int CourseID { get; set; }

        public virtual Course Cours { get; set; }

        public virtual Prof Prof { get; set; }

        public virtual Student Student { get; set; }
    }
}
