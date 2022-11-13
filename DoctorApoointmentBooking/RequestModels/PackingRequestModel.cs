using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.RequestModels
{
    public class PackingRequestModel : BaseResponse
    {
       public bool IsAssigned { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
