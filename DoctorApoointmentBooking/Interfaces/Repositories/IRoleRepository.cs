using DoctorApoointmentBooking.Entites;

namespace DoctorApoointmentBooking.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        public Role RegisterRole(Role role);
        public Role FindRoleById(int id);
        public Role FindRoleByName(string name);
        public Role UpdateRole(Role role);
        public List<Role> GetAllRoles();
        public void DeleteRole(int id);
    }

}
