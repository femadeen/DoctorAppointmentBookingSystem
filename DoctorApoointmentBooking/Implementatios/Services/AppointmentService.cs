using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Interfaces.Repositories;
using DoctorApoointmentBooking.Interfaces.Services;
using DoctorApoointmentBooking.Models;
using DoctorApoointmentBooking.RequestModels;

namespace DoctorApoointmentBooking.Implementatios.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRespository;
        private readonly IPatientRepository _patientRespositoryRepository;
        private readonly IPackingRepository _packingRepository;
        private readonly IDoctorRepository _doctorRepository;
        public AppointmentService(IAppointmentRepository appointmentRespository,
            IPatientRepository patientRespository, IPackingRepository  packingRepository,
            IDoctorRepository doctorRepository)
        {
            _appointmentRespository = appointmentRespository;
            _patientRespositoryRepository = patientRespository;
            _packingRepository = packingRepository;
            _doctorRepository = doctorRepository;
        }

        public BaseResponse ApprovedAppointment(int appointmentId)
        {
            var appointment = _appointmentRespository.GetAppointment(appointmentId);
            if(appointment == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " Error occured! appointment does nor exist"
                };
            }
            appointment.Status = Enums.AppointmentStatus.Assigned;
            _appointmentRespository.Update(appointment);
            return new BaseResponse
            {
                Status = true,
                Message = "Appointment is being approved"
            };
        }

        public BaseResponse MakeAppointment(AppointmentBookingRequest request)
        {
            var patientWithCode = _patientRespositoryRepository.GetPatientByPatientCode(request.patientCode);
            var pateintWithId = _patientRespositoryRepository.FindPatientById(request.PatientId);
            if(pateintWithId == null || patientWithCode == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " Patient does not exist"
                };
            }
            var packingSpace = _packingRepository.GetAvailablePAckingSpace();
            if(request.IsDriving && packingSpace.Count == 0)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "No available packing space"
                };
            }
            var availableDoctorBaseOnUnit = _doctorRepository.GetDoctorsAvailableByProffessionAndTime(request.UnitFacility, request.AppointmentTime);
            if(availableDoctorBaseOnUnit == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " No availble doctor, please chech back"
                };
            }
            var scheduleTime = DateTime.Now.AddHours(2);
            if(request.AppointmentTime < scheduleTime)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Past Lapse time for booking an appointment"
                };
            }
            var appointment = new Appointment
            {
                PatientId = request.PatientId,
                AppointmentDate = request.AppointmentTime,
                AppointmentReason = request.ReasonForAppointment,
                DateCreated = DateTime.Now,
                AppointmentReferenceNumber = Guid.NewGuid().ToString(),
                Status = Enums.AppointmentStatus.Pending,
                //DoctorId = availableDoctorBaseOnUnit.Take(1).Select(d => d.Id).First(),
                DoctorId = availableDoctorBaseOnUnit.First().Id,
                AppointmentDuration = DateTime.Now,
                ParkingId = packingSpace.First().Id,   
                
            };
            _appointmentRespository.Create(appointment);
            return new BaseResponse
            {
                Status = true,
                Message = "Appointment successfully booked, kindly await Admin's confirmation Number"
            };


        }
    }
}
