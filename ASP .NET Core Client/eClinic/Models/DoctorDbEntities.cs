using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eClinic.Models
{
    public class DoctorDbEntities : DbContext
    {
        public DoctorDbEntities()
        {
        }

        public DoctorDbEntities(DbContextOptions<DoctorDbEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctor { get; set; }
        //public virtual DbSet<Post> Post { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=10.0.75.1;Database=Clinic;User Id=sa;Password=Qwerty123!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorPesel).IsRequired();
            });

            //modelBuilder.Entity<Doctor>(entity =>
            //{
            //    entity.HasOne(d => d.FirstName);
            //});
        }
    }
    }
