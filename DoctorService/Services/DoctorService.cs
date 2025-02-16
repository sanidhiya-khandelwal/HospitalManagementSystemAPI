using DoctorService.Models;
using DoctorService.Repositories;

namespace DoctorService.Services
{
    public class DoctorService: IDoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Doctor>> GetAllDoctors() => _repository.GetAllDoctors();
        public Task<Doctor> GetDoctorById(int id) => _repository.GetDoctorById(id);
        public Task<bool> AddDoctor(Doctor doctor) => _repository.AddDoctor(doctor);
        public Task<bool> UpdateDoctor(Doctor doctor) => _repository.UpdateDoctor(doctor);
        public Task<bool> DeleteDoctor(int id) => _repository.DeleteDoctor(id);
    }
}
