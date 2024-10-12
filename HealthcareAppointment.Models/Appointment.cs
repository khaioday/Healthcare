using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        [Required]
        public Guid PatientId { get; set; } // Foreign Key to User (Patient)

        [Required]
        public Guid DoctorId { get; set; } // Foreign Key to User (Doctor)

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public AppointmentStatus Status { get; set; } // Enum: Scheduled, Completed, Cancelled

        // Navigation properties
        public User Patient { get; set; } // Patient object (Navigation)
        public User Doctor { get; set; } // Doctor object (Navigation)
    }
    public enum AppointmentStatus
    {
        Scheduled,
        Completed,
        Cancelled
    }

}
