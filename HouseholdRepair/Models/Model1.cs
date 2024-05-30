using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HouseholdRepair.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<Manager>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Requests>()
                .Property(e => e.TypeEquipment)
                .IsUnicode(false);

            modelBuilder.Entity<Requests>()
                .Property(e => e.DescriptionRepair)
                .IsUnicode(false);

            modelBuilder.Entity<Requests>()
                .Property(e => e.RequestStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Requests>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
