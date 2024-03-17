using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Entities.Context
{
    public class PatientsAppointmentsContext : DbContext
    {

        public PatientsAppointmentsContext() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>()
                .Property(p => p.Dosage)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Treatment>()
                .Property(t => t.Cost)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Appointment>()
                .HasKey("AppointmentDate", "DoctorId", "PatientId");
            modelBuilder.Entity<Appointment>()
                .HasIndex("AppointmentDate", "DoctorId").IsUnique();
            modelBuilder.Entity<Appointment>()
                .HasIndex("AppointmentDate", "PatientId").IsUnique();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=HospitalManagementSystem;Trusted_Connection=True; TrustServerCertificate=True;");
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}