using DoctorApoointmentBooking.Interfaces.Repositories;
using DoctorApoointmentBooking.Interfaces.Services;
using DoctorApoointmentBooking.RequestModels;
using DoctorApoointmentBooking.ResponseModels;

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
            throw new NotImplementedException();
        }

        public UserResponseModel GetUserByEmail(string Email)
        {
            throw new NotImplementedException();
        }

        public UserResponseModel GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public UserResponseModel Login(LoginRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}
