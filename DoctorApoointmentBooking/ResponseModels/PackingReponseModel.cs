using DoctorApoointmentBooking.DTOs;
using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.ResponseModels
{
    public class PackingReponseModel : BaseResponse
    {
        public PackingDto Data { get; set; }
    }
}

