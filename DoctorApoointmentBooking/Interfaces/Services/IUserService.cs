using DoctorApoointmentBooking.RequestModels;
using DoctorApoointmentBooking.ResponseModels;

namespace DoctorApoointmentBooking.Interfaces.Services
{
    public interface IUserService
    {
        UserResponseModel Login(LoginRequestModel model);
        UsersResponseModel GetAllUSers();
        UserResponseModel GetUserById(int id);
    }
}
