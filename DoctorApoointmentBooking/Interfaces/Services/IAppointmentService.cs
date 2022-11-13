using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Models;
using DoctorApoointmentBooking.RequestModels;
using DoctorApoointmentBooking.ResponseModels;

namespace DoctorApoointmentBooking.Interfaces.Services
{
    public interface IAppointmentService
    {
        BaseResponse MakeAppointment(AppointmentBookingRequest request);
        BaseResponse ApprovedAppointment(int appointmentId);
        AppointmentResponseModel AppointmentConfimationNumber(Appointment Apppointment);
        AppointmentResponseModel CancelUnappovedAppointment(CancelBookedAppointmentRequestModel model);
        BaseResponse RecommendAppointmentByDoctor(AppointmentBookingRequest request);
        Task<BaseResponse> RequestToCancelApprovedAppointment(CancelBookedAppointmentRequestModel model);

    }
}
