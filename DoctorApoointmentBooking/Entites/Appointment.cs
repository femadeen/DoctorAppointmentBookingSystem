using DoctorApoointmentBooking.Enums;
using DoctorApoointmentBooking.Implementatios.Services;

namespace DoctorApoointmentBooking.Entites
{
    public class Appointment
    {
        public int Id { get; set; }
        public string AppointmentReferenceNumber { get; set; }
        public string AppointmentReason { get; set; }
        public DateTime AppointmentDuration { get; set; }
        public bool IsDriving { get; set; }
        public int PatientId { get; set; }
        public int? ParkingId { get; set; }
        public Packing PackingSpace { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime DateCreated {get; set; }
        public AppointmentStatus Status { get; set; }
        public int? DoctorId { get; set; }
        public string DoctorComment { get; set; } 
        public MedicalRecord MedicalRecord { get; set; }
        public int medicaRecordId { get; set; }
    }
}
