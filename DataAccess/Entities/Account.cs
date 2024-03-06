using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = null!;
        public int? RoleId { get; set; }

        public virtual Role? Role { get; set; }
    }
}
