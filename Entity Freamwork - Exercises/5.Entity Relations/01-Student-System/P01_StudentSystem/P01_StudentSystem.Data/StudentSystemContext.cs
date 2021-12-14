using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.CONNECTION_STRING);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<StudentCourse>(e =>
            //{
            //    e.HasKey(e => new
            //    {
            //        e.StudentId,
            //        e.CourseId
            //    });
            //});

            modelBuilder.Entity<Course>().Property(x => x.Name).IsUnicode();

            modelBuilder.Entity<Course>().Property(x => x.Description).IsUnicode().IsRequired(false);

            modelBuilder.Entity<Student>().Property(x => x.Name).IsUnicode();


            modelBuilder.Entity<Resource>().Property(x => x.Name).IsUnicode();
            
            modelBuilder.Entity<Homework>().Property(x => x.Content).IsUnicode(false);

            modelBuilder.Entity<StudentCourse>(x =>
            {
                x.HasKey(x => new { x.CourseId, x.StudentId });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
