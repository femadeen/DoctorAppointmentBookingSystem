using DoctorApoointmentBooking.DTOs;

namespace DoctorApoointmentBooking.ResponseModels
{
    public class PackingsReponseModel
    {
        public IEnumerable<PackingDto> Data { get; set; } = new List<PackingDto>();
    }
}
