using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.ResponseModels
{
    public class AppointmentsResponseModel : BaseResponse
    {
        public IEnumerable<AppointmentDto> Appointments { get; set; } = new List<AppointmentDto>();
    }
}
