using DoctorApoointmentBooking.Entites;

namespace DoctorApoointmentBooking.DTO
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PatientAddress { get; set; }
        public double? PhoneNumber { get; set; }
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<AppointmentDto> Appointments { get; set; } = new List<AppointmentDto>();
    }
}
