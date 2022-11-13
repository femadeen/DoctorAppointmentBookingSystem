using DoctorApoointmentBooking.Entites;

namespace DoctorApoointmentBooking.Interfaces.Repositories
{
    public interface IAppointmentRepository
    {
        Appointment Create(Appointment appointment);
        Appointment Update(Appointment appointment);
        Appointment GetAppointment(int id);
        IList<Appointment> GetAllAppoinments();
        public void DeleteAppointment(int id);
        IList<Appointment> GetAllAppoinmentsByPatient(int patientId);
        IList<Appointment> GetAllAppoinmentsByDoctor(int doctorId);
        Appointment GetAppointmentByReferenceNumber(string referenceNumber);
         Appointment GetAppointmentByDoctorByDate(int doctorId,  DateTime date);
        bool GetDoctorAvailability(int doctorId, DateTime date);

    }
}
