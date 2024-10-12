using HealthcareAppointment.Business;
using HealthcareAppointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAppointment.WebAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
        {
            _service = service;
        }

        // GET: api/appointments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(Guid id)
        {
            var appointment = await _service.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        // Additional CRUD operations for appointments can be added here

        // Example: Schedule an appointment
        [HttpPost]
        public async Task<IActionResult> ScheduleAppointment([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddAppointment(appointment);
            return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
        }

        // PUT: api/appointments/{id} - Update an appointment
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest("ID mismatch");
            }

            await _service.UpdateAppointment(appointment);
            return NoContent();
        }

        // DELETE: api/appointments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            await _service.DeleteAppointment(id);
            return NoContent();
        }

        // PATCH: api/appointments/{id}/cancel - Cancel an appointment
        [HttpPatch("{id}/cancel")]
        public async Task<IActionResult> CancelAppointment(Guid id)
        {
            await _service.CancelAppointment(id);
            return NoContent();
        }
    }
}
