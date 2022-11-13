using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.ResponseModels
{
    public class AppointmentResponseModel : BaseResponse
    {
        public AppointmentDto Data {get; set;}
    }
}
