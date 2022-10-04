using DoctorApoointmentBooking.Entites;

namespace DoctorApoointmentBooking.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        public Admin RegisterAdmin(Admin admin);
        public bool Exist(string firstName, string lastname);
        public Admin FindAdminById(int id);
        public Admin FindAdminByEmail(string email);
        public void DeleteAdmin(int id);
        public Admin UpdateAdmin(Admin admin);
        public List<Admin> GetAllAdmins();

    }
}
