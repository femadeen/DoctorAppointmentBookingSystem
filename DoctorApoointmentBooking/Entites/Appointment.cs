using DoctorApoointmentBooking.Enums;

namespace DoctorApoointmentBooking.Entites
{
    public class Appointment
    {
        public int Id { get; set; }
        public string AppointmentReferenceNumber { get; set; }
        public string AppointmentReason { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime DateCreated {get; set; }
        public AppointmentStatus Status { get; set; }
        public int? DoctorId { get; set; }
        public string DoctorComment { get; set; }   
        
    }
}
