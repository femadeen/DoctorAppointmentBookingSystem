using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Enums;

namespace DoctorApoointmentBooking.DTO
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public string AppointmentReason { get; set; }
        public int PatientId { get; set; }
        public PatientDto PatientDto { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime DateCreated { get; set; }
        public string DoctorComment { get; set; }
    }
}
