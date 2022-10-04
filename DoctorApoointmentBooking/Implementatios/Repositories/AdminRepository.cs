using DoctorApoointmentBooking.DoctorAppointmentContext;
using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Interfaces.Repositories;

namespace DoctorApoointmentBooking.Implementatios.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DoctorAppointmentDbContext _context;
        public AdminRepository(DoctorAppointmentDbContext context)
        {
            _context = context;
        }
        public void DeleteAdmin(int id)
        {
            var admin = FindAdminById(id);
            _context.Admins.Remove(admin);
            _context.SaveChanges();
        }

        public bool Exist(string firstName, string lastName)
        {
            var isExisting = _context.Admins.Any(a => a.FirstName.ToLower() == firstName.ToLower()
            && a.LastName.ToLower() == lastName);
            return isExisting;
        }

        public Admin FindAdminByEmail(string email)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Email == email);
            return admin;
        }

        public Admin FindAdminById(int id)
        {
            var admin = _context.Admins.SingleOrDefault(a => a.Id == id);
            return admin;
        }

        public List<Admin> GetAllAdmins()
        {
            var admins = _context.Admins.ToList();
            return admins;
        }

        public Admin RegisterAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return admin;
        }

        public Admin UpdateAdmin(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
            return admin;
        }
    }
}
