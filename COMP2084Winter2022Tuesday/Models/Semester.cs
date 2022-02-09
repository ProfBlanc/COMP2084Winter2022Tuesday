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
        public int SemesterID { get; set; }

        [Required]
        [StringLength(6)]
        public string Term { get; set; }

        public decimal Year { get; set; }

        public int ProfID { get; set; }

        public int StudentID { get; set; }

        public int CourseID { get; set; }

        public virtual Course Cours { get; set; }

        public virtual Prof Prof { get; set; }

        public virtual Student Student { get; set; }
    }
}