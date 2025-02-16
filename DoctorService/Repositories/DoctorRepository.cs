using Dapper;
using DoctorService.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DoctorService.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly string _connectionString;

        public DoctorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Doctor>("GetAllDoctors", commandType: CommandType.StoredProcedure);
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Doctor>(
                "GetDoctorById", new { DoctorID = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> AddDoctor(Doctor doctor)
        {
            using var connection = new SqlConnection(_connectionString);
            var result = await connection.ExecuteAsync("AddDoctor", new
            {
                doctor.FirstName,
                doctor.LastName,
                doctor.Specialization,
                doctor.ContactNumber,
                doctor.Email,
                doctor.IsActive
            }, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> UpdateDoctor(Doctor doctor)
        {
            using var connection = new SqlConnection(_connectionString);
            var result = await connection.ExecuteAsync("UpdateDoctor", new
            {
                doctor.DoctorID,
                doctor.FirstName,
                doctor.LastName,
                doctor.Specialization,
                doctor.ContactNumber,
                doctor.Email,
                doctor.IsActive
            }, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> DeleteDoctor(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var result = await connection.ExecuteAsync("DeleteDoctor", new { DoctorID = id }, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }
}
