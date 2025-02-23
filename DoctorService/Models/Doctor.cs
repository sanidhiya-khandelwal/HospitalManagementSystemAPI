namespace DoctorService.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public int ExperienceYears { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
