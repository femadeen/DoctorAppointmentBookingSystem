using DoctorApoointmentBooking.Models;
using DoctorApoointmentBooking.RequestModels;

namespace DoctorApoointmentBooking.Interfaces.Services
{
    public interface IAppointmentService
    {
        BaseResponse MakeAppointment(AppointmentBookingRequest request);

    }
}
