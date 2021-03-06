using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace COMP2084Winter2022Tuesday.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext2")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Prof> Profs { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.Semesters)
                .WithRequired(e => e.Cours)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prof>()
                .HasMany(e => e.Semesters)
                .WithRequired(e => e.Prof)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<School>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.School)
                .HasForeignKey(e => e.SchoolAttending)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Semester>()
                .Property(e => e.Year)
                .HasPrecision(4, 0);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Semesters)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);
        }
    }
}
