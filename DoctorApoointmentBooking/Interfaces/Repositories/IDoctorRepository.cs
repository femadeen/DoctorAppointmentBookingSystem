using DoctorApoointmentBooking.Entites;

namespace DoctorApoointmentBooking.Interfaces.Repositories
{
    public interface IDoctorRepository
    {
        public Doctor RegisterDoctor(Doctor doctor);
        public Doctor FindDoctorById(int id);
        public Doctor FindDoctorByEmail(string email);
        public void DeleteDoctor(int id);
        public Doctor UpdateDoctor(Doctor doctor);
        public List<Doctor> GetAllDoctors();
        public bool Exist(string firstName, string lastName);
        public bool CheckAnyAvailableDoctor();
        public List<Doctor> GetDoctorsByDailyHoursOFWork(Doctor doctors);
        public List<Doctor> GetDoctorsByProffesion(string doctorProffesion);
        public List<Doctor> GetDoctorsAvailableByProffessionAndTime(string doctorProffesion, DateTime dateTime);
      
    }
}
