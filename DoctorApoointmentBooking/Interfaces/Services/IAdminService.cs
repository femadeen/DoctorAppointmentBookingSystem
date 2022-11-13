using DoctorApoointmentBooking.Models;
using DoctorApoointmentBooking.RequestModels;
using DoctorApoointmentBooking.ResponseModels;

namespace DoctorApoointmentBooking.Interfaces.Services
{
    public interface IAdminService
    {
        BaseResponse RegisterAdmin(RegisterAdminRequestModel model);
        BaseResponse UpdateAdmin(int iD, UpdateAdminRequestModel model);
        AdminResponseModel DeleteAdmin(int adminId);
        AdminResponseModel GetAdminById(int adminId);
        AdminsResponseModel GetAllAdmins();
    }
}
