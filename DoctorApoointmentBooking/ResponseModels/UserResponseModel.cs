using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.ResponseModels
{
    public class UserResponseModel : BaseResponse
    {
        public UserDto Data { get; set; }
    }
}
