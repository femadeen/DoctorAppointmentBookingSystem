using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Interfaces.Repositories;
using DoctorApoointmentBooking.Interfaces.Services;
using DoctorApoointmentBooking.RequestModels;
using DoctorApoointmentBooking.ResponseModels;
using System.Linq.Expressions;

namespace DoctorApoointmentBooking.Implementatios.Services
{
    public class UserService : IUserService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAdminRepository  _adminRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;
        public UserService(IPatientRepository patientRepository, IAdminRepository adminRepository, IDoctorRepository doctorRepository, IUserRepository userRepository)
        {
            _patientRepository = patientRepository;
            _adminRepository = adminRepository;
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
        }
        

        public UsersResponseModel GetAllUSers()
        {
            var users = _userRepository.GetAllUsers();
            var returnedUsers = users.Select(u => new UserDto
            {
                Id = u.Id,
                Email = u.Email,
                RoleName = u.Role.Name
            });
            return new UsersResponseModel
            {
                Data = returnedUsers,
                Status = true,
                Message = "Users Retreived successfully"
            };
        }

        public UserResponseModel GetUserById(int id)
        {
            var user = _userRepository.FindUserById(id);
            if(user == null)
            {
                return new UserResponseModel
                {
                    Status = false,
                    Message = " No such user exist"
                };
            }
            if(user.Role.Name.ToLower() == "patient")
            {
                return new UserResponseModel
                {
                    Data = new UserDto
                    {
                        Email = user.Email,
                        FirstName = user.Patient.FirstName,
                        LastName = user.Patient.LastName,
                        RoleName = user.Role.Name
                    },
                    Status = true,
                    Message = " User (Patient) retreived Successfully"
                };
            }
            if(user.Role.Name.ToLower() == "admin")
            {
                return new UserResponseModel
                {
                    Data = new UserDto
                    {
                        Email = user.Email,
                        FirstName = user.Admin.FirstName,
                        LastName = user.Admin.LastName,
                        RoleName = user.Role.Name
                    },
                    Status = true,
                    Message = "User (Admin) retreived Successfully"
                };
            }
            else
            {
                return new UserResponseModel
                {
                    Data = new UserDto
                    {
                        Email = user.Email,
                        FirstName = user.Doctor.FirstName,
                        LastName = user.Doctor.LastName,
                        RoleName = user.Role.Name
                    },
                    Status = true,
                    Message = "User (Doctor) retreived Successfully "
                };
            }

        }

        public UserResponseModel Login(LoginRequestModel model)
        {
            var user = _userRepository.FindUserByEmail(model.Email);
            if(user == null)
            {
                return new UserResponseModel
                {
                    Status = false,
                    Message = "No Such User exist"
                };
            }
            var passwordCheck = BCrypt.Net.BCrypt.Verify($"{model.Passwrord}{user.HashSalt}", user.PasswordHash);
            if(passwordCheck)
            {
                if(user.Role.Name.ToLower() == "patient")
                {
                    return new UserResponseModel
                    {
                        Data = new UserDto
                        {
                            Email = user.Email,
                            FirstName = user.Patient.FirstName,
                            LastName = user.Patient.LastName,
                            RoleId = user.Role.Id,
                            RoleName = user.Role.Name
                        },
                        Status = true,
                        Message = "Login Sucessfully"
                    };
                }
                if(user.Role.Name.ToLower() == "admin")
                {
                    return new UserResponseModel
                    {
                        Data = new UserDto
                        {
                            Email = user.Email,
                            FirstName = user.Admin.FirstName,
                            LastName = user.Admin.LastName,
                            RoleId = user.RoleId,
                            RoleName = user.Role.Name
                        },
                        Status = true,
                        Message = "Login successfully"
                    };
                }
                else
                {
                    return new UserResponseModel
                    {
                        Data = new UserDto
                        {
                            Email = user.Email,
                            FirstName = user.Doctor.FirstName,
                            LastName = user.Doctor.LastName,
                            RoleId = user.RoleId,
                            RoleName = user.Role.Name
                        },
                        Status = true,
                        Message = "Login successfully"
                    };
                }
            }
            else
            {
                return new UserResponseModel
                {
                    Status = false,
                    Message = " Email / Password Invalid"
                };
            }
        }
    }
}
