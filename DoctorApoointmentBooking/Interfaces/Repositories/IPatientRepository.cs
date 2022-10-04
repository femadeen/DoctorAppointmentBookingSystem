using DoctorApoointmentBooking.Entites;

namespace DoctorApoointmentBooking.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        public Patient RegisterPatient(Patient patient);
        public Patient FindPatientById(int id);
        public Patient FindpatientByEmail(string email);
        public void DeletePatient(int id);
        public List<Patient> GetAllPatients();
        public bool Exist(string firstName, string lastName);
        public Patient UpdatePatient(Patient patient);
    }
}
