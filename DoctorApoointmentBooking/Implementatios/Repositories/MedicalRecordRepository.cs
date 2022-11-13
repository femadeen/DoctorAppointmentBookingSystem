using DoctorApoointmentBooking.DoctorAppointmentContext;
using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DoctorApoointmentBooking.Implementatios.Repositories
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly DoctorAppointmentDbContext _context;
        public MedicalRecordRepository(DoctorAppointmentDbContext context)
        {
            _context = context;
        }

        public Task<MedicalRecord> GetAllMedicalRecords()
        {
            throw new NotImplementedException();
        }

        public async Task<MedicalRecord> GetMedicalrecord(int appointmentId)
        {
           var medicalRecord =  _context.MedicalRecords
                .Include(a => a.Appointment)
                .ThenInclude(d => d.DoctorComment)
                .SingleOrDefault(m => m.Id == appointmentId);
            return medicalRecord;
        }
    }
}
