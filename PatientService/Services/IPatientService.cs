using PatientService.Models;

namespace PatientService.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int id);
        Task<bool> AddPatient(Patient patient);
        Task<bool> UpdatePatient(Patient patient);
        Task<bool> DeletePatient(int id);
    }
}
