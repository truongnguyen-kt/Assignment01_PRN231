using Assignment01.Utils.Request;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
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
            if (id == null)
            {
                throw new MissingFieldException(nameof(id));
            }
            return await _context.Roles.FindAsync(id);
        }
        public async Task AddRole(Role role)
        {
            if (role == null)
            {
                throw new MissingFieldException($"{nameof(role)} is null");
            }
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task<Role> GetRoleByName(string name)
        {
            name = name.Trim().ToUpper();
            if (name == null || name.Length == 0)
            {
                throw new MissingFieldException($"{nameof(name)}");
            }
            return await _context.Roles.FirstOrDefaultAsync(x => x.RoleName.Trim().ToUpper().Equals(name));
        }
    }
}
