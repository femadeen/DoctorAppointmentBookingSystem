using DoctorApoointmentBooking.Enums;

namespace DoctorApoointmentBooking.Entites
{
    public class Packing
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public PatientPacking PackingSpace { get; set; }

    }
}
