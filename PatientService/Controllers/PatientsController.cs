using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PatientService.Models;
using PatientService.Services;

namespace PatientService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return Ok(await _service.GetAllPatients());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients(int id)
        {
            var patient = await _service.GetPatientById(id);
            return patient == null ? NotFound() : Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
           return await _service.AddPatient(patient) ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatient(Patient patient)
        {
           return await _service.UpdatePatient(patient) ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            return await _service.DeletePatient(id) ? Ok() : BadRequest();
        }
    }
}
