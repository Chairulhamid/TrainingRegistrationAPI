using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Models;

namespace TrainingRegistrationAPI.Context
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Modul> Moduls { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<RegisteredCourse> RegisteredCourses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<CourseFeedback> CourseFeedback { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to one => Account to User
            modelBuilder.Entity<Account>()
                 .HasOne(a => a.User)
                 .WithOne(b => b.Account)
                 .HasForeignKey<User>(b => b.AccountId);

            //One to one => Account to Employee
            modelBuilder.Entity<Account>()
                 .HasOne(a => a.Employee)
                 .WithOne(b => b.Account)
                 .HasForeignKey<Employee>(b => b.AccountId);

            //One to one => RegisteredCourse to Payment
            modelBuilder.Entity<RegisteredCourse>()
                .HasOne(a => a.Payment)
                .WithOne(b => b.RegisteredCourse)
                .HasForeignKey<Payment>(b => b.RegisteredCourseId);

            //One to one => feedback to user
            modelBuilder.Entity<User>()
                .HasOne(a => a.Feedback)
                .WithOne(b => b.User)
                .HasForeignKey<Feedback>(b => b.UserId);

            /*//One to one => feedback to user
            modelBuilder.Entity<Feedback>()
                .HasOne(a => a.User)
                .WithOne(b => b.Feedback)
                .HasForeignKey<User>(b => b.UserId);*/

            modelBuilder.Entity<RegisteredCourse>()
                .HasOne(a => a.CourseFeedback)
                .WithOne(b => b.RegisteredCourse)
                .HasForeignKey<CourseFeedback>(b => b.RegisteredCourseId);

            //Many to many Role
            modelBuilder.Entity<AccountRole>()
              .HasKey(bc => new { bc.AccountId, bc.RoleId });
            modelBuilder.Entity<AccountRole>()
                .HasOne(bc => bc.Account)
                .WithMany(b => b.AccountRoles)
                .HasForeignKey(bc => bc.AccountId);
            modelBuilder.Entity<AccountRole>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.AccountRoles)
                .HasForeignKey(bc => bc.RoleId); 
            /*modelBuilder.Entity<RegisteredCourse>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.RegisteredCourse);*/

            modelBuilder.Entity<Course>()
              .HasOne(a => a.Employee)
              .WithMany(b => b.Course);
            modelBuilder.Entity<Modul>()
              .HasOne(a => a.Course)
              .WithMany(b => b.Modul);
            modelBuilder.Entity<Course>()
              .HasOne(a => a.Topic)
              .WithMany(b => b.Course);
            modelBuilder.Entity<RegisteredCourse>()
              .HasOne(a => a.User)
              .WithMany(b => b.RegisteredCourses);
            /*modelBuilder.Entity<User>()
              .HasMany(a => a.RegisteredCourse)
              .WithOne(b => b.User);*/
            modelBuilder.Entity<Course>()
              .HasMany(a => a.RegisteredCourse)
              .WithOne(b => b.Course);

        }
    }
}
