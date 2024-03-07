using Assignment01.Repository;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepo;
using System.Security.Principal;

namespace Assignment01.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole(string roleName)
        {
            try
            {
                Role role = await _roleRepository.GetRoleByName(roleName);
                if (role == null)
                {
                    await _roleRepository.AddRole(new DataAccess.Entities.Role
                    {
                        RoleName = roleName.Trim()
                    });
                    return StatusCode(200, "Add Role Successfully");
                }
                else
                {
                    return StatusCode(200, "RoleName already exist!");
                }
            }
            catch (Exception ex)
            {
                int statusCode;
                string errorMessage;
                statusCode = 500;
                errorMessage = "Server error";
                return StatusCode(statusCode, errorMessage);
            }
        }
    }
}
