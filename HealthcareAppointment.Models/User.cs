using System.ComponentModel.DataAnnotations;

namespace HealthcareAppointment.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required, MinLength(3), MaxLength(255)]
        public string Name { get; set; }
        [Required, EmailAddress, MinLength(5), MaxLength(255)]
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }
        public UserRole Role { get; set; } // Enum: Patient, Doctor
        [MaxLength(255)]
        public string Specialization { get; set; } // For Doctor only
    }

    public enum UserRole
    {
        Patient,
        Doctor
    }

}
