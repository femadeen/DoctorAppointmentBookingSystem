﻿using DoctorApoointmentBooking.Entites;

namespace DoctorApoointmentBooking.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        public Role RegisterUser(Role role);
        public Role FindUserById(int id);
        public Role FindUserByEmail(string email);
        public Role UpdateRole(Role role);
        public List<Role> GetAllRoles();
        public void DeleteRole(int id);
    }

}
