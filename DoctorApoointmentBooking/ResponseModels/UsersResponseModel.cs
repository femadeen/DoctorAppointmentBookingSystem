using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.ResponseModels
{
    public class UsersResponseModel : BaseResponse
    {
        public IEnumerable<UserDto> Data { get; set; } = new List<UserDto>();
    }
}
