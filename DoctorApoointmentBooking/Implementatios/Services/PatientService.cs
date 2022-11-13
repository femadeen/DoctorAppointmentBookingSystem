using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Interfaces.Repositories;
using DoctorApoointmentBooking.Interfaces.Services;
using DoctorApoointmentBooking.Models;
using DoctorApoointmentBooking.RequestModels;
using DoctorApoointmentBooking.ResponseModels;
using System.Reflection.Metadata.Ecma335;

namespace DoctorApoointmentBooking.Implementatios.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        public PatientService(IPatientRepository patientRepository, IUserRepository userRepository, IRoleRepository roleRepository, IAppointmentRepository appointmentRepository)
        {
            _patientRepository = patientRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _appointmentRepository = appointmentRepository;
        }

        

        public PatientResponseModel DeletePatient(int patientId)
        {
            var patient = _patientRepository.FindPatientById(patientId);
            if (patient == null)
                return new PatientResponseModel
                {
                    Status = false,
                    Message = "No such Patient Exist"
                };
            _patientRepository.DeletePatient(patientId);
            return new PatientResponseModel
            {
                Status = true,
                Message = "Patent deleted Successfully"
            };
        }

        public PatientsResponseModel GetAllPatients()
        {
           var patients = _patientRepository.GetAllPatients();
            var returnedPatient = patients.Select(p => new PatientDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                PatientAddress = p.PatientAddress,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
            });
            return new PatientsResponseModel
            {
               Data = returnedPatient,
               Status = true,
               Message = " All patients retreived successfully"
            };
            
        }

        public PatientResponseModel GetPatientById(int patientId)
        {
            var patient = _patientRepository.FindPatientById(patientId);
            if (patient == null)
                return new PatientResponseModel
                {
                    Status = false,
                    Message = "No such Patient exist"
                };
            return new PatientResponseModel
            {
                Data = new DTO.PatientDto
                {
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    DateOfBirth = patient.DateOfBirth,
                    PatientAddress = patient.PatientAddress,
                    Email = patient.Email,
                    PhoneNumber = patient.PhoneNumber,
                },
                Status = true,
                Message = "Patient's data retruived successfully"
            };
        }

        public BaseResponse RegisterPatient(RegisterPatientRequestModel model)
        {
            var userExist = _userRepository.FindUserByEmail(model.Email);
            if (userExist != null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "User already exist"
                };
            }
            var patientExist = _patientRepository.Exist(model.FirstName, model.FirstName);
            if(patientExist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Patient already exist"
                };
            }
            var role = _roleRepository.FindRoleByName("Patient");
            var salt = Guid.NewGuid().ToString();
            var hashPassword = BCrypt.Net.BCrypt.HashPassword($"{model.password}{salt}");
            var user = new User
            {
              Email = model.Email,
              RoleId = role.Id,
              HashSalt = salt,
              PasswordHash = hashPassword
            };
            var patient = new Patient
            {
                FirstName = model.FirstName,
                LastName =  model.LastName,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                PatientAddress = model.PatientAdresss,
                PhoneNumber = model.PhoneNumber,
                User = user,
                UserId = user.Id,
                PatientCode = $"P{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 5).ToUpper()}{model.FirstName[0]}{model.LastName[0]}",
            };
            _userRepository.RegisterUser(user);
            _patientRepository.RegisterPatient(patient);
            return new BaseResponse
            {
                Status = true,
                Message = "Patient registered successfully"
            };
        }

        public BaseResponse UpdatePatient(int id, UpdatePatientRequestModel model)
        {
            var patient = _patientRepository.FindPatientById(id);
            if(patient == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "No such patient exist"
                };  
            }
            patient.FirstName = model.FirstName;
            patient.LastName = model.LastName;
            patient.Email = model.Email;
            patient.PhoneNumber = model.PhoneNumber;
            patient.PatientAddress = model.PatientAddress;
            _patientRepository.UpdatePatient(patient);
            return new BaseResponse
            {
                Status = true,
                Message = "Patient data Updated successfully"
            };
        }
    }
}
