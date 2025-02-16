using DoctorService.Models;

namespace DoctorService.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorById(int id);
        Task<bool> AddDoctor(Doctor doctor);
        Task<bool> UpdateDoctor(Doctor doctor);
        Task<bool> DeleteDoctor(int id);
    }
}
