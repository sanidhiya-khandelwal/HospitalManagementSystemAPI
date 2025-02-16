using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using PatientService.Models;


namespace PatientService.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly string _connectionString;
        public PatientRepository(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Patient>("GetAllPatients", commandType: CommandType.StoredProcedure);
        }
        public async Task<bool> AddPatient(Patient patient)
        {
            using var connection = new SqlConnection(_connectionString);
            var result = await connection.ExecuteAsync("AddPatient", new
            {
                patient.FirstName,
                patient.LastName,
                patient.DateOfBirth,
                patient.ContactNumber,
                patient.Email,
                patient.IsActive,
            }, commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> DeletePatient(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var result =  await connection.ExecuteAsync(
                "DeletePatient", new { PatientID = id }, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        

        public async Task<Patient> GetPatientById(int id)
        {
           using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Patient>(
                "GetPatientById", new { PatientID = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdatePatient(Patient patient)
        {
            using var connection = new SqlConnection(_connectionString);
            var result = await connection.ExecuteAsync("UpdatePatient", new
            {
                patient.PatientID,
                patient.FirstName,
                patient.LastName,
                patient.DateOfBirth,
                patient.ContactNumber,
                patient.Email,
                patient.IsActive,
            }, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}
