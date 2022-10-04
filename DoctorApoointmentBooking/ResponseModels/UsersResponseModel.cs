using DoctorApoointmentBooking.DTO;

namespace DoctorApoointmentBooking.ResponseModels
{
    public class UsersResponseModel
    {
        public IEnumerable<UserDto> Data { get; set; } = new List<UserDto>();
    }
}
