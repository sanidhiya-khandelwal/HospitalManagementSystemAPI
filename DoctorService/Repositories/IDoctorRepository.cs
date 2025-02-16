using DoctorService.Models;

namespace DoctorService.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<bool> AddDoctor(Doctor doctor);
        Task<bool> UpdateDoctor(Doctor doctor);
        Task<bool> DeleteDoctor(int id);
    }
}
