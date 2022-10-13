using DoctorApoointmentBooking.DoctorAppointmentContext;
using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Interfaces.Repositories;

namespace DoctorApoointmentBooking.Implementatios.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorAppointmentDbContext _context;
        public DoctorRepository(DoctorAppointmentDbContext context)
        {
            _context = context;
        }

        public bool CheckAnyAvailableDoctor()
        {
            var response = _context.Doctors.Any(d => d.IsAvailable == true);
            return response;
        }

        public void DeleteDoctor(int id)
        {
            var doctor = FindDoctorById(id);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }

        public bool Exist(string firstName, string lastName)
        {
            var isExisting = _context.Doctors.Any(d => d.FirstName.ToLower() == firstName.ToLower()
            && d.LastName.ToLower() == lastName.ToLower());
            return isExisting;
        }

        public Doctor FindDoctorByEmail(string email)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Email.ToLower() == email.ToLower());
            return doctor;
        }


        public Doctor FindDoctorById(int id)
        {
            var doctor = _context.Doctors.SingleOrDefault(d => d.Id == id);
            return doctor;
        }

        public List<Doctor> GetAllDoctors()
        {
            var doctors = _context.Doctors.ToList();
            return doctors;
        }

        public List<Doctor> GetDoctorsAvailableByProffessionAndTime(string doctorProffesion, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctorsByDailyHoursOFWork(Doctor doctors)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctorsByProffesion(string doctorProffession)
        {
            var doctorProfessions = _context.Doctors.Where(d => d.DoctorProffession.ToLower() == doctorProffession.ToLower()).ToList();
            return doctorProfessions; 
        }

        public Doctor RegisterDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
            return doctor;
        }
    }
}
