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

        public void DeleteAppointment(int id)
        {
            var appointment = GetAppointment(id);
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
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

        public Appointment GetAppointmentByDoctorByDate(int doctorId, DateTime date)
        {
            var appointment = _context.Appointments
                .Include(d => d.Doctor)
                .ThenInclude(d => d.Appointments)
                .Include(d => d.AppointmentDate)
                .SingleOrDefault(a => a.DoctorId == doctorId && a.AppointmentDate == date);
            return appointment;
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
