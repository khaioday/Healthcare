using HealthcareAppointment.Models;

namespace HealthcareAppointment.Business
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAppointments();
        Task<Appointment> GetAppointmentById(Guid id);
        Task AddAppointment(Appointment appointment);
        Task UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(Guid id);
        Task CancelAppointment(Guid id);
    }

}
