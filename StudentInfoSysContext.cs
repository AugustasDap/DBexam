using DBexam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBexam
{
    public class StudentInfoSysContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=StudentInfoSys;Trusted_Connection=True");
        //public StudentInfoSysContext(DbContextOptions<StudentInfoSysContext> options) : base(options)
        //{
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.DepartmentId);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Lectures)
                .WithMany(l => l.Students);

            modelBuilder.Entity<Lecture>()
                .HasMany(l => l.Departments)
                .WithMany(d => d.Lectures);
        }
    }

}
