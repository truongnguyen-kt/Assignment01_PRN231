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
        public Role GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(x => (x.Id == id));
        }
    }
}
