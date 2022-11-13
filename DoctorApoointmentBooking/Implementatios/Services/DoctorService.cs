using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Enums;
using DoctorApoointmentBooking.Interfaces.Repositories;
using DoctorApoointmentBooking.Interfaces.Services;
using DoctorApoointmentBooking.Models;
using DoctorApoointmentBooking.RequestModels;
using DoctorApoointmentBooking.ResponseModels;

namespace DoctorApoointmentBooking.Implementatios.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        public DoctorService(IDoctorRepository doctorRepository, IUserRepository userRepository, IRoleRepository roleRepository, IAppointmentRepository appointmentRepository, IPatientRepository patientRepository)
        {
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
        }

        public BaseResponse AdmitPatient(int appointmentId)
        {
          
        }

        public DoctorResponseModel DeleteDoctor(int id)
        {
            var doctor = _doctorRepository.FindDoctorById(id);
            if(doctor == null)
            {
                return new DoctorResponseModel
                {
                    Status = true,
                    Message = "No such Doctor exist"
                };
            }
            _doctorRepository.DeleteDoctor(id);
            return new DoctorResponseModel
            {
                Status = true,
                Message = " Doctor deleted successfully"
            };
        }

        public DoctorsResponseModel GetAllDoctors()
        {
            var doctors = _doctorRepository.GetAllDoctors();
            var retrievedDoctors = doctors.Select(d => new DoctorDto
            {
                FirstName = d.FirstName,
                LastName = d.LastName,
                Email = d.Email,
                DoctorProfession = d.DoctorProffession
            });
            return new DoctorsResponseModel
            {
                Data = retrievedDoctors,
                Status = true,
                Message = "All doctors retreived successfully"
            };
        }

        public DoctorResponseModel GetDocotrByProffession(string DoctorProffession)
        {
            var doctor = _doctorRepository.GetDoctorsByProffesion(DoctorProffession);
            if(doctor == null)
            {
                return new DoctorResponseModel
                {
                    Status = false,
                    Message = "No such Doctor exist"
                };
            }
            return new DoctorResponseModel
            {
                Data = new DoctorDto
                {
                    DoctorProfession = DoctorProffession,
                },
                Status = true,
                Message = "Doctor's proffession retrieved successfully"
            };
        }

        public DoctorResponseModel GetDoctorById(int id)
        {
            var doctor = _doctorRepository.FindDoctorById(id);
            if(doctor == null)
            {
                return new DoctorResponseModel
                {
                    Status = false,
                    Message = "No such Doctor exist"
                };
            }
            return new DoctorResponseModel
            {
                Data = new DoctorDto
                {
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.Email,
                },
                Status = true,
                Message = "Doctor's data retreived successfully"
            };
        }

        public BaseResponse RegisterDoctor(RegisterDoctorRequestModel model)
        {
            var userExist = _userRepository.FindUserByEmail(model.Email);
            if(userExist != null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " User Already Exist"
                };
            }
            var doctorExist = _doctorRepository.Exist(model.FirstName, model.LastName);
            if(doctorExist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " Doctor already Exist"
                };
            }
            var role = _roleRepository.FindRoleByName("Doctor");
            var salt = Guid.NewGuid().ToString();
            var hashPassword = BCrypt.Net.BCrypt.HashPassword($"{model.Password}{salt}");
            var user = new User
            {
                Email = model.Email,
                RoleId = role.Id,
                HashSalt = salt,
                PasswordHash = hashPassword
            };
            var doctor = new Doctor
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserId = user.Id,
                User = user,
                DoctorProffession = model.Proffession,
                DoctorCode = $"D{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 5).ToUpper()}{model.FirstName[0]}{model.LastName[0]}",
            };
            _userRepository.RegisterUser(user);
            _doctorRepository.RegisterDoctor(doctor);
            return new BaseResponse
            {
                Status = true,
                Message = " Doctor registered successfully"
            };
        }

        public BaseResponse UpdateDoctor(int Id, UpdateDoctorRequestModel model)
        {
            var doctor = _doctorRepository.FindDoctorById(Id);
            if(doctor == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " No Such Doctor available"
                };
            }
            doctor.FirstName = model.FirstName;
            doctor.LastName = model.LastName;
            doctor.Email = model.Email;
            doctor.DoctorProffession = model.DoctorProffession;
            _doctorRepository.UpdateDoctor(doctor);
            return new BaseResponse
            {
                Status = true,
                Message = "Doctor's profile updated successfully"
            };
        }
    }
}
