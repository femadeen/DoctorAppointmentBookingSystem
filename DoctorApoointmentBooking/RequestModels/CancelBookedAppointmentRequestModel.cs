using DoctorApoointmentBooking.Models;

namespace DoctorApoointmentBooking.RequestModels
{
    public class CancelBookedAppointmentRequestModel : BaseResponse
    {
        public int AppointmentId { get; set; }
        public string ReasonForCancleAppointment { get; set; }
    }
}
