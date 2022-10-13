using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.Entites
{
    public class Doctor : Person
    {
        public string DoctorCode { get; set; }
        public string DoctorProffession { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime DailyHoursOfWork { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public bool IsAvailable { get; set; }
    }
}
