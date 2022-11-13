using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.ResponseModels
{
    public class PatientsResponseModel : BaseResponse
    {
        public IEnumerable<PatientDto> Data { get; set; } = new List<PatientDto>();
    }
}
