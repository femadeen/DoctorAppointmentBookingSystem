using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.ResponseModels
{
    public class DoctorsResponseModel : BaseResponse
    {
        public IEnumerable<DoctorDto> Data { get; set; } = new List<DoctorDto>();
    }
}
