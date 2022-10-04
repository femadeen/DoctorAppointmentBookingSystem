using DoctorApoointmentBooking.DoctorAppointmentContext;
using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Interfaces.Repositories;

namespace DoctorApoointmentBooking.Implementatios.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DoctorAppointmentDbContext _context;
        public PatientRepository(DoctorAppointmentDbContext context)
        {
            _context = context;
        }

        public void DeletePatient(int id)
        {
            var patient = FindPatientById(id);
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }

        public bool Exist(string firstName, string lastName)
        {
            var isExisting = _context.Patients.Any(p => p.FirstName.ToLower() == firstName.ToLower()
            && p.LastName.ToLower() == lastName.ToLower());
            return isExisting;
        }

        public Patient FindpatientByEmail(string email)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Email.ToLower() == email.ToLower());
            return patient;
        }

        public Patient FindPatientById(int id)
        {
            var patient = _context.Patients.SingleOrDefault(x => x.Id == id);
            return patient;
        }

        public List<Patient> GetAllPatients()
        {
            var patients = _context.Patients.ToList();
            return patients;
        }

        public Patient RegisterPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient;
        }

        public Patient UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
            return patient;
        }
    }
}
