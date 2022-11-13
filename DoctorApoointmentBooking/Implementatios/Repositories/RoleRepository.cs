using DoctorApoointmentBooking.DoctorAppointmentContext;
using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Interfaces.Repositories;

namespace DoctorApoointmentBooking.Implementatios.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DoctorAppointmentDbContext _context;
        public RoleRepository(DoctorAppointmentDbContext context)
        {
            _context = context;
        }
        public void DeleteRole(int id)
        {
            throw new NotImplementedException();
        }

        public Role FindRoleById(int id)
        {
            var role = _context.Roles.SingleOrDefault(r => r.Id == id);
            return role;
        }

        public Role FindRoleByName(string name)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Name.ToLower() == name.ToLower());
            return role;
        }

        public List<Role> GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public Role RegisterRole(Role role)
        {
            throw new NotImplementedException();
        }

        public Role UpdateRole(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
