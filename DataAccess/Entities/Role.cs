﻿using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
