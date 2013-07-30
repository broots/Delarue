using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Delarue.JB.Entities
{
    public class DelarueContext : DbContext
    {
        public DelarueContext() : base("DelarueDb") { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(em => em.EmployeeCode)
                .IsRequired();
            modelBuilder.Entity<Employee>().Property(em => em.Name)
                .IsRequired()
                .IsVariableLength()
                .HasMaxLength(100);
        }
    }
}