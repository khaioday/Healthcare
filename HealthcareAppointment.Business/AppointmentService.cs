using HealthcareAppointment.Data;
using HealthcareAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Business
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _repository;

        public AppointmentService(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments() => await _repository.GetAll();

        public async Task<Appointment> GetAppointmentById(Guid id) => await _repository.GetById(id);

        public async Task AddAppointment(Appointment appointment)
        {
            // Business logic (e.g., validation for appointment date, doctor availability)
            await _repository.Add(appointment);
        }

        public async Task UpdateAppointment(Appointment appointment) => await _repository.Update(appointment);

        public async Task DeleteAppointment(Guid id) => await _repository.Delete(id);

        public async Task CancelAppointment(Guid id)
        {
            var appointment = await _repository.GetById(id);
            if (appointment != null)
            {
                appointment.Status = AppointmentStatus.Cancelled;
                await _repository.Update(appointment);
            }
        }
    }

}
