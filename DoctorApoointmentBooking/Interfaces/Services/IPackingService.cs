using DoctorApoointmentBooking.Models;
using DoctorApoointmentBooking.RequestModels;
using DoctorApoointmentBooking.ResponseModels;

namespace DoctorApoointmentBooking.Interfaces.Services
{
    public interface IPackingService
    {
        BaseResponse AssignedPackingSpace(int appointmentId);
        PackingsReponseModel GetAllAvailablePackingSpace();
        BaseResponse UnassignedPackingSpace(int appointmentId);
        PackingReponseModel GetPackingSpaceByAppointment(int aapoitmentId);
    }
}
