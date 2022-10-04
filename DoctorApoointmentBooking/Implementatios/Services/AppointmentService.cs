using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Interfaces.Repositories;
using DoctorApoointmentBooking.Interfaces.Services;
using DoctorApoointmentBooking.Models;
using DoctorApoointmentBooking.RequestModels;

namespace DoctorApoointmentBooking.Implementatios.Services
{
    public class AppointmentService : IAppointmentService
    {
        public BaseResponse MakeAppointment(AppointmentBookingRequest request)
        {
            var appointment = new Appointment
            {
                PatientId = request.PatientId,
                AppointmentDate = request.AppointmentTime,
                AppointmentReason = request.ReasonForAppointment,
                DateCreated = DateTime.Now,
                AppointmentReferenceNumber = Guid.NewGuid().ToString(),
                Status = Enums.AppointmentStatus.Pending
            };

        }
    }
}
