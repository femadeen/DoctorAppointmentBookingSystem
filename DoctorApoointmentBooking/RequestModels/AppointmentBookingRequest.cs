namespace DoctorApoointmentBooking.RequestModels
{
    public class AppointmentBookingRequest
    {
        public int PatientId { get; set; }
        public string PatientCode { get; set; }
        public string UnitFacility { get; set; }
        public bool IsDriving { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string ReasonForAppointment { get; set; }

    }

}

