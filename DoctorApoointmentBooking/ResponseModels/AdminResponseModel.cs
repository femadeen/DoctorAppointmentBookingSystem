using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.ResponseModels
{
    public class AdminResponseModel : BaseResponse
    {
        public AdminDto Data { get; set; }
    }
}
