using DoctorApoointmentBooking.Entites;

namespace DoctorApoointmentBooking.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}
