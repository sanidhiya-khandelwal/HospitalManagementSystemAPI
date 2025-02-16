using Microsoft.AspNetCore.Mvc;
using DoctorService.Models;
using DoctorService.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorsController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors() => Ok(await _service.GetAllDoctors());

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _service.GetDoctorById(id);
            return doctor == null ? NotFound() : Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(Doctor doctor) =>
            await _service.AddDoctor(doctor) ? Ok() : BadRequest();

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor(Doctor doctor) =>
            await _service.UpdateDoctor(doctor) ? Ok() : BadRequest();

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id) =>
            await _service.DeleteDoctor(id) ? Ok() : BadRequest();
    }
}
