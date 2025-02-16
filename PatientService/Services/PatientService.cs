using PatientService.Models;
using PatientService.Repositories;

namespace PatientService.Services
{
    public class PatientService : IPatientService
    {
        public readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }
        public Task<bool> AddPatient(Patient patient)
        {
            return _repository.AddPatient(patient);
        }

        public Task<bool> DeletePatient(int id)
        {
            return _repository.DeletePatient(id);
        }

        public Task<IEnumerable<Patient>> GetAllPatients()
        {
           return _repository.GetAllPatients();
        }

        public Task<Patient> GetPatientById(int id)
        {
            return _repository.GetPatientById(id);
        }

        public Task<bool> UpdatePatient(Patient patient)
        {
            return _repository.UpdatePatient(patient);
        }
    }
}
