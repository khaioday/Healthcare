using HealthcareAppointment.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointment.Data
{
    public class HealthcareDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne<User>(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasOne<User>(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.DoctorId);
        }
    }


}
