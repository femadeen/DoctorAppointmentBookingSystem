using DoctorApoointmentBooking.DTO;
using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Interfaces.Repositories;
using DoctorApoointmentBooking.Interfaces.Services;
using DoctorApoointmentBooking.Models;
using DoctorApoointmentBooking.RequestModels;
using DoctorApoointmentBooking.ResponseModels;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace DoctorApoointmentBooking.Implementatios.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public AdminResponseModel DeleteAdmin(int adminId)
        {
            var admin = _adminRepository.FindAdminById(adminId);
            if(admin == null)
            {
                return new AdminResponseModel
                {
                    Status = false,
                    Message = " No such Admin exist"
                };
            }
            _adminRepository.DeleteAdmin(adminId);
            return new AdminResponseModel
            {
                Status = true,
                Message = " Admin successfully deleted"
            };
        }

        public AdminResponseModel GetAdminById(int adminId)
        {
            var admin = _adminRepository.FindAdminById(adminId);
            if( admin == null)
            {
                return new AdminResponseModel
                {
                    Status = false,
                    Message = "No such admin exist"
                };
            }
            return new AdminResponseModel
            {
                Data = new AdminDto
                {
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Email = admin.Email,
                },
                Status = true,
                Message = " Admin data retreived successfully"
            };
        }

        public AdminsResponseModel GetAllAdmins()
        {
            var admins = _adminRepository.GetAllAdmins();
            var adminRetreived = admins.Select(a => new AdminDto
            {
                FirstName = a.FirstName,
                LastName= a.LastName,
                Email= a.Email,
            });
            return new AdminsResponseModel
            {
                Data = adminRetreived,
                Status = true,
                Message = " All admins retreived successfully"
            };
        }

        public BaseResponse RegisterAdmin(RegisterAdminRequestModel model)
        {
            var userExit = _userRepository.FindUserByEmail(model.Email);
            if(userExit != null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " User already exist"
                };
            }
            var adminExist = _adminRepository.Exist(model.FirstName, model.LastName);
            if(adminExist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " Admin with this info already exist"
                };
            }
            var role = _roleRepository.FindRoleByName("Admin");
            var salt = Guid.NewGuid().ToString();
            var hashPassword = BCrypt.Net.BCrypt.HashPassword($"{model.Password}{salt}");
            var user = new User
            {
                Email = model.Email,
                RoleId = role.Id,
                HashSalt = salt,
                PasswordHash = hashPassword
            };
            var admin = new Admin
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                User = user,
                UserId = user.Id,
                AdminCode = $"A{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 5).ToUpper()}{model.FirstName[0]}{model.LastName[0]}",
            };
            _userRepository.RegisterUser(user);
            _adminRepository.RegisterAdmin(admin);
            return new BaseResponse
            {
                Status = true,
                Message = " Admin Successfully registered"
            };
        }

        public BaseResponse UpdateAdmin(int iD, UpdateAdminRequestModel model)
        {
            var admin = _adminRepository.FindAdminById(iD);
            if(admin == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = " No such admin exist"
                };
            }
            admin.FirstName = model.FirstName;
            admin.LastName = model.LastName;
            admin.Email = model.Email;
            return new BaseResponse
            {
                Status = true,
                Message = " Admin profile successfully Updated"
            };
        }
    }
}
