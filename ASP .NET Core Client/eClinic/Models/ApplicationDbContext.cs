using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eClinic.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext() { }

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<DoctorLogin> DoctorLogin { get; set; }
        public DbSet<PatientLogin> PatientLogin { get; set; }
        public DbSet<Patient> Patient { get; set; }
                                           //public virtual DbSet<Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>()
                .Property(a => a.RowVersion)
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            //modelBuilder.Entity<Doctor>(entity =>
            //{
            //    entity.HasOne(d => d.FirstName);
            //});
        }
    }
    }
