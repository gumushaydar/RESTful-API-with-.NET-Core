using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPI.Models;

namespace TeacherStudentAPI.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Teacher> Teachers  { get; set; }
        public DbSet<Student> Students { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Teacher>().ToTable("Teachers");
            builder.Entity<Teacher>().HasKey(p => p.Id);
            builder.Entity<Teacher>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Teacher>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Teacher>().Property(p => p.DepartmentName).IsRequired().HasMaxLength(30);
            builder.Entity<Teacher>().HasMany(p => p.Students).WithOne(p => p.Teacher).HasForeignKey(p => p.TeacherID);

            builder.Entity<Teacher>().HasData
                (
                new Teacher { Id = 125, Name = "John Doe", DepartmentName = "Bussiness" },      // Id set manually due to in-memory provider
                new Teacher { Id = 126, Name = "Ahmer Necdet", DepartmentName = "Engineering" }
                );

            builder.Entity<Student>().ToTable("Students");
            builder.Entity<Student>().HasKey(p => p.Id);
            builder.Entity<Student>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Student>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Student>().Property(p => p.DepartmentName).IsRequired();
            builder.Entity<Student>().Property(p => p.Season).IsRequired();

            builder.Entity<Student>().HasData
                (
                new Student
                {
                    Id = 111,
                    Name = "Jason",
                    DepartmentName = "Bussiness",
                    Season = " Junior",
                    TeacherID =125
                },
                new Student
                {
                    Id = 112,
                    Name = "Sara",
                    DepartmentName = "Computer Engineering",
                    Season = "Middle",
                    TeacherID = 126
                   
                },
                new Student
                {
                    Id = 113,
                    Name = "Melissa",
                    DepartmentName = "Industrial Engineering",
                    Season = "Senior",
                    TeacherID = 126
                });

        }

    }
}
