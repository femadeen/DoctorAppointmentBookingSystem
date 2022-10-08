using DoctorApoointmentBooking.DoctorAppointmentContext;
using DoctorApoointmentBooking.Entites;
using DoctorApoointmentBooking.Interfaces.Repositories;
using Microsoft.AspNetCore.Components.Forms;

namespace DoctorApoointmentBooking.Implementatios.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DoctorAppointmentDbContext _context;
        public UserRepository(DoctorAppointmentDbContext context)
        {
            _context = context;
        }

        public void DeleteUser(int id)
        {
            var user = FindUserById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User FindUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            return user;
        }

        public User FindUserById(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            return user;
        }

        public List<User> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public User RegisterUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
