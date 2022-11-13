using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Implementatios.Repositories;
using DoctorApoointmentBooking.Interfaces.Repositories;
using DoctorApoointmentBooking.Interfaces.Services;
using DoctorApoointmentBooking.Models;
using DoctorApoointmentBooking.RequestModels;
using DoctorApoointmentBooking.ResponseModels;

namespace DoctorApoointmentBooking.Implementatios.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRespository;
        private readonly IPackingRepository _packingRepository;
        private readonly IDoctorRepository _doctorRepository;
        public AppointmentService(IAppointmentRepository appointmentRespository,
            IPatientRepository patientRespository, IPackingRepository  packingRepository,
            IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRespository;
            _patientRespository = patientRespository;
            _packingRepository = packingRepository;
            _doctorRepository = doctorRepository;
        }

        public AppointmentResponseModel AppointmentConfimationNumber(Appointment appointment)
        {
            var appoinmentByPatient = _appointmentRepository.GetAllAppoinmentsByPatient(appointment.PatientId);
            if(appointment== null)
            {
                return new AppointmentResponseModel
                {
                    Status = false,
                    Message = " Appointment can not be approved"
                };
            }
            var approvedAppointment = _appointmentRepository.GetAppointmentByDoctorByDate(appointment.Doctor.Id, appointment.AppointmentDate);
            if(approvedAppointment != null)
            {
                return new AppointmentResponseModel
                {
                    Data = new AppointmentDto
                    {
                        AppointmentConfirmationNumber = $"P{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 5).ToUpper()}" +
                        $"{appointment.Patient.FirstName[0]}{appointment.Patient.LastName[0]}"
                    },
                    Status = true,
                    Message = "Appointment Confirmed with confimation provided"
                };
            }
            return new AppointmentResponseModel
            {
                Status = false,
                Message = "We're sorr! Appointment was deneid due to short of Doctors "
            };

            
        }

        public BaseResponse ApprovedAppointment(int appointmentId)
        {
            var appointment = _appointmentRepository.GetAppointment(appointmentId);
            if(appointment == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " Error occured! appointment does not exist"
                };
            }
            appointment.Status = Enums.AppointmentStatus.Assigned;
            _appointmentRepository.Update(appointment);
            var packingSpace = _packingRepository.GetFirstAvailablePAckingSpace();
            if (appointment.IsDriving == true)
            {
                
                if (packingSpace != null)
                {
                    packingSpace.IsAssigned = true;
                    _packingRepository.UpdatePacking(packingSpace);
                    appointment.ParkingId = packingSpace.Id;
                    _appointmentRepository.Update(appointment);
                }
                else
                {
                    return new BaseResponse
                    {
                        Status = false,
                        Message = "No Packing space Available"
                    };
                }
            }
            return new BaseResponse
            {
                Status = true,
                Message = $"Appointment is being approved and your packing number is {packingSpace.PackingNo}"
            };
        }

        public BaseResponse MakeAppointment(AppointmentBookingRequest request)
        {
            var patientWithCode = _patientRespository.GetPatientByPatientCode(request.PatientCode);
            var patientWithId = _patientRespository.FindPatientById(request.PatientId);
            if(patientWithId == null || patientWithCode == null)
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
            _appointmentRepository.Create(appointment);
            return new BaseResponse
            {
                Status = true,
                Message = "Appointment successfully booked, kindly await Admin's confirmation Number"
            };
        }
        public AppointmentResponseModel CancelUnapprovedAppointment(CancelBookedAppointmentRequestModel model)
        {
            var appointment = _appointmentRepository.GetAppointment(model.AppointmentId);
            if (appointment == null)
            {
                return new AppointmentResponseModel
                {
                    Status = false,
                    Message = "No such Appointment exist in our Systmem"
                };
            }
            var reasonForCancellation = model.ReasonForCancleAppointment;
            appointment.Status = Enums.AppointmentStatus.Cancel;
            _appointmentRepository.DeleteAppointment(model.AppointmentId);
            _appointmentRepository.Update(appointment);
            return new AppointmentResponseModel
            {
                Status = true, 
                Message = " Appointment canceled Successfully"
            };
        }

        public AppointmentResponseModel CancelUnappovedAppointment(CancelBookedAppointmentRequestModel model)
        {
            throw new NotImplementedException();
        }

        public BaseResponse RecommendAppointmentByDoctor(AppointmentBookingRequest request)
        {
            var patientWithId = _patientRespository.FindPatientById(request.PatientId);
            if(patientWithId == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Patient not found"
                };
            }
            var appointment = new Appointment
            {
                PatientId = request.PatientId,
                AppointmentDate = request.AppointmentTime,
                AppointmentReason = request.ReasonForAppointment,
                DateCreated = DateTime.Now,
                AppointmentReferenceNumber = Guid.NewGuid().ToString(),
                Status = Enums.AppointmentStatus.Assigned,
                AppointmentDuration = DateTime.Now,
                
            };
            return new BaseResponse
            {
                Status = true,
                Message = "Appointment Created Succesfully"
            };

        }

        public async Task<BaseResponse> RequestToCancelApprovedAppointment(CancelBookedAppointmentRequestModel model)
        {
            var appointment = _appointmentRepository.GetAppointment(model.AppointmentId);
            if(appointment == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "No such appointment exist"
                };
            }
            var requestToCancleAppt = model.ReasonForCancleAppointment;
            return new BaseResponse
            {
                Status = true, 
                Message = "Wait for an approval confrimation "
            };

        }
    }
}
