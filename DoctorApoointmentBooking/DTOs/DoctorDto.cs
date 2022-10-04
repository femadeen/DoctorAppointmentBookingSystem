using DoctorApoointmentBooking.Entites;

namespace DoctorApoointmentBooking.DTO
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }
        public ICollection<AppointmentDto> Appointments { get; set; } = new List<AppointmentDto>();
    }
}    
       
