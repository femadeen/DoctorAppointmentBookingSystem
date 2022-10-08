using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.ResponseModels
{
    public class DoctorResponseModel : BaseResponse
    {
        public DoctorDto Data { get; set; }
    }
}
