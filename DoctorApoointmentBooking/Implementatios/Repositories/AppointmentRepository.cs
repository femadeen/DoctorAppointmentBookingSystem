using DoctorApoointmentBooking.DoctorAppointmentContext;
using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DoctorApoointmentBooking.Implementatios.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DoctorAppointmentDbContext _context;
        public AppointmentRepository(DoctorAppointmentDbContext context)
        {
            _context = context;
        }

        public Appointment Create(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public IList<Appointment> GetAllAppoinments()
        {
            var appointments = _context.Appointments.ToList();
            return  appointments;
            
        }

        public IList<Appointment> GetAllAppoinmentsByDoctor(int doctorId)
        {
            var appointments = _context.Appointments.Where(d => d.Id == doctorId).ToList();
            return appointments;
        }

        public IList<Appointment> GetAllAppoinmentsByPatient(int patientId)
        {
            var appointments = _context.Appointments.Where(p => p.Id == patientId).ToList();
            return appointments;
        }

        public Appointment GetAppointment(int id)
        {
           var appointment = _context.Appointments.SingleOrDefault(a=> a.Id == id);
            return appointment;
        }

        public List<Appointment> GetAppointmentByDoctorByDate(int doctorId, DateTime date)
        {
            var appointment = _context.Appointments
                .Include(d => d.Doctor)
                .ThenInclude(d => d.AppointmentDate)
                .Include(d => d.Doctor)
                .ThenInclude(d => d.DailyHoursOfWork !< DateTime.Now.ToString("02:00"))
                
        }

        public Appointment GetAppointmentByReferenceNumber(string referenceNumber)
        {
            var appointment = _context.Appointments.SingleOrDefault(a => a.AppointmentReferenceNumber
            == referenceNumber);
            return appointment;
        }

        public bool GetDoctorAvailability(int doctorId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Appointment Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
            return appointment;

        }
    }
}
