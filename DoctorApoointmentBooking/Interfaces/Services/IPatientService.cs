using DoctorApoointmentBooking.Models;
using DoctorApoointmentBooking.RequestModels;
using DoctorApoointmentBooking.ResponseModels;

namespace DoctorApoointmentBooking.Interfaces.Services
{
    public interface IPatientService
    {
        BaseResponse RegisterPatient(RegisterPatientRequestModel model);
        BaseResponse UpdatePatient(int id, UpdatePatientRequestModel model);
        PatientResponseModel DeletePatient(int patientId);
        PatientResponseModel GetPatientById(int patientId);
        PatientsResponseModel GetAllPatients();
    }
}
