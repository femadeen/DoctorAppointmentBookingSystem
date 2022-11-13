using DoctorApoointmentBooking.Entites;

namespace DoctorApoointmentBooking.Interfaces.Repositories
{
    public interface IMedicalRecordRepository
    {
        Task<MedicalRecord> GetMedicalrecord(int appointmentId);
        Task<MedicalRecord> GetAllMedicalRecords();
    }
}
