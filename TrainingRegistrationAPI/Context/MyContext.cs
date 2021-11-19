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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One to one => Account to User
            modelBuilder.Entity<User>()
                .HasOne(a => a.Account)
                .WithOne(b => b.User)
                .HasForeignKey<Account>(b => b.AccountId);

            //One to one => Account to Employee
            modelBuilder.Entity<Employee>()
                .HasOne(a => a.Account)
                .WithOne(b => b.Employee)
                .HasForeignKey<Account>(b => b.AccountId);

            //Many to Many => Role
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

            /* //One to one => Account to Profilling
             modelBuilder.Entity<Account>()
                 .HasOne(a => a.Profilling)
                 .WithOne(b => b.Account)
                 .HasForeignKey<Profilling>(b => b.NIK);

             //Many  to Many => Univetsity to Education
             modelBuilder.Entity<University>()
                 .HasMany(c => c.Educations)
                 .WithOne(e => e.University);

             //One to Many => Education to Profilling
             modelBuilder.Entity<Education>()
               .HasMany(c => c.Profillings)
               .WithOne(e => e.Education);

             //One to Many => Education to Profilling
             modelBuilder.Entity<Education>()
               .HasMany(c => c.Profillings)
               .WithOne(e => e.Education); */

            
        }
    }
}
