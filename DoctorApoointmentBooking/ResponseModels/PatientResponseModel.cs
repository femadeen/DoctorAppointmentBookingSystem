using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.ResponseModels
{
    public class PatientResponseModel : BaseResponse
    {
        public PatientDto Data { get; set; }
    }
}
