namespace DoctorApoointmentBooking.Entites
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HashSalt { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public Admin Admin { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
