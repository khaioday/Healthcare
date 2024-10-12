using HealthcareAppointment.Data;
using HealthcareAppointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAppointment.WebAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IRepository<User> _repository;

        public PatientsController(IRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients() => Ok(await _repository.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(Guid id) => Ok(await _repository.GetById(id));

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] User patient)
        {
            if (patient.Role != UserRole.Patient) return BadRequest("Invalid role");
            await _repository.Add(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(Guid id, [FromBody] User patient)
        {
            if (id != patient.Id) return BadRequest("Invalid ID");
            await _repository.Update(patient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }

}
