using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.ResponseModels
{
    public class AdminsResponseModel : BaseResponse
    {
        public IEnumerable<AdminDto> Data { get; set; } = new List<AdminDto>();
    }
}
