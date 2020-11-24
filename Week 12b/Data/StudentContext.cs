using System;
using Microsoft.EntityFrameworkCore;
using Week_12b.Models;

namespace Week_12b.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext (DbContextOptions<StudentContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");

            modelBuilder.Entity<Student>().HasKey(std => new{std.Id});
        }

        public DbSet<Student> Students {get; set;}
    }
}