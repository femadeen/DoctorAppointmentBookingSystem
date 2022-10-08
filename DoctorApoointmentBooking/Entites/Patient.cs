using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.Entites
{
    public class Patient : Person
    {
        public string PatientCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ParkingId { get; set; }
        public Packing Packing { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
