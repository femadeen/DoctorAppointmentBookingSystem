using DoctorApoointmentBooking.Entites;

namespace DoctorApoointmentBooking.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public User RegisterUser(User user);
        public User FindUserById(int id);
        public User FindUserByEmail(string email);
        public User UpdateUser(User user);
        public List<User> GetAllUsers();
        public void DeleteUser(int id);
    }
}
