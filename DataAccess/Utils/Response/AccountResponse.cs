using DataAccess.Entities;

namespace Assignment01.Utils.Response
{
    public class AccountResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public Role Role { get; set; }
    }
}
