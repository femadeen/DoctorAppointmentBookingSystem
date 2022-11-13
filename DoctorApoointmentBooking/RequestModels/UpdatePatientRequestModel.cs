namespace DoctorApoointmentBooking.RequestModels
{
    public class UpdatePatientRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public double PhoneNumber { get; set; }
        public string PatientAddress { get; set; }
    }
}
