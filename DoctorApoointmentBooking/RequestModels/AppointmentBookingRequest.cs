namespace DoctorApoointmentBooking.RequestModels
{
    public class AppointmentBookingRequest
    {
        public int PatientId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string ReasonForAppointment { get; set; }

    }

}

