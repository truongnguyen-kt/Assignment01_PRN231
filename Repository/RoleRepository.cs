using DataAccess.Context;
using DataAccess.Entities;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly assignment_prn_231Context _context;
        public RoleRepository(assignment_prn_231Context context)
        {
            _context = context;
        }
        public async Task<Role> GetRoleById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }
    }
}
