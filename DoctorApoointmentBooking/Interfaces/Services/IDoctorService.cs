using DoctorApoointmentBooking.Models;
using DoctorApoointmentBooking.RequestModels;
using DoctorApoointmentBooking.ResponseModels;

namespace DoctorApoointmentBooking.Interfaces.Services
{
    public interface IDoctorService
    {
        BaseResponse RegisterDoctor(RegisterDoctorRequestModel model);
        BaseResponse UpdateDoctor(int Id, UpdateDoctorRequestModel model);
        DoctorResponseModel GetDoctorById(int id);
        DoctorResponseModel GetDocotrByProffession(String DoctorProffession);
        DoctorsResponseModel GetAllDoctors();
        DoctorResponseModel DeleteDoctor(int Id);
    }
}
