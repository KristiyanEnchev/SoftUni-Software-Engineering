using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(x => x.Name).IsUnicode().IsRequired(true);

            modelBuilder.Entity<Course>().Property(x => x.Description).IsUnicode(true).IsRequired(false);
            modelBuilder.Entity<Course>().Property(c => c.StartDate)
               .IsRequired(true);

            modelBuilder.Entity<Course>().Property(c => c.EndDate)
                .IsRequired(true);

            modelBuilder.Entity<Course>().Property(c => c.Price)
                .IsRequired(true);

            modelBuilder.Entity<Student>().Property(x => x.Name).IsUnicode(true).IsRequired(true);

            modelBuilder.Entity<Student>().Property(s => s.RegisteredOn)
               .IsRequired(true);

            modelBuilder.Entity<Student>().Property(s => s.Birthday)
                .IsRequired(false);
            modelBuilder.Entity<Student>().Property(s => s.PhoneNumber)
              .IsRequired(false)
              .IsUnicode(false);

            modelBuilder.Entity<Resource>().Property(x => x.Name).IsUnicode(true).IsRequired(true);
            modelBuilder.Entity<Resource>().Property(r => r.Url)
             .IsRequired(true)
             .IsUnicode(false);

            modelBuilder.Entity<Resource>()
                .HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Homework>().Property(x => x.Content).IsUnicode(false).IsRequired(true);

            modelBuilder.Entity<Homework>().Property(h => h.SubmissionTime)
               .IsRequired(true);

            modelBuilder.Entity<Homework>()
                .HasOne(h => h.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(h => h.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Homework>()
                .HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(h => h.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentCourse>(x =>
            {
                x.HasKey(x => new { x.CourseId, x.StudentId });
            });
            modelBuilder.Entity<StudentCourse>()
           .HasOne(st => st.Course)
           .WithMany(c => c.StudentsEnrolled)
           .HasForeignKey(st => st.CourseId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(st => st.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(st => st.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);


        }
    }
}
