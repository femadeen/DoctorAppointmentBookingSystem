namespace DoctorApoointmentBooking.Entites
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public Appointment Appointment { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
