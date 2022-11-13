using DoctorApoointmentBooking.Enums;
using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.Entites
{
    public class Doctor : Person
    {
        public string DoctorCode { get; set; }
        public string DoctorProffession { get; set; } 
        public DateTime TotalHoursOfWork { get; set; }
        public LabResults LabResult { get; set; }
        public string DoctorTreatmentReport { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public bool IsAvailable { get; set; }
    }
}
