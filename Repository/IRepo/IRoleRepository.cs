using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepo
{
    public interface IRoleRepository
    {
        public Task<Role> GetRoleById(int id);
        public Task AddRole(Role role);
        public Task<Role> GetRoleByName(string name);
    }
}
