using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Interfaces.Repositories;
using DoctorApoointmentBooking.Interfaces.Services;
using DoctorApoointmentBooking.Models;
using DoctorApoointmentBooking.RequestModels;
using DoctorApoointmentBooking.ResponseModels;

namespace DoctorApoointmentBooking.Implementatios.Services
{
    public class PackingService : IPackingService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPackingRepository _packingRepository;
        public PackingService(IAppointmentRepository appointmentRepository, IPackingRepository packingRepository)
        {
            _appointmentRepository = appointmentRepository;
            _packingRepository = packingRepository;
        }

        public BaseResponse AssignedPackingSpace(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse CreatePackingSpace()
        {
            throw new NotImplementedException();
        }

        public PackingsReponseModel GetAllAvailablePackingSpace()
        {
            throw new NotImplementedException();
        }

        public PackingReponseModel GetPackingSpaceByAppointment(int aapoitmentId)
        {
            throw new NotImplementedException();
        }

        public BaseResponse UnassignedPackingSpace(int appointmentId)
        {
            throw new NotImplementedException();
        }
    }
}
