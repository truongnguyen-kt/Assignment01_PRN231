using Assignment01.Utils.Request;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepo;
using Repository.Token;

namespace Assignment01.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _config;
        public AccountController(IAccountRepository accountRepository, IConfiguration config)
        {
            _accountRepository = accountRepository;
            _config = config;
            ProvideToken.Initialize(config);
        }

        [HttpGet("get-account-by-id/{id}")]
        public async Task<IActionResult> GetAccoutById(int id)
        {
            try
            {
                var account = await _accountRepository.GetAccountById(id);
                if (account != null)
                {
                    return StatusCode(200, account);
                }
                else return StatusCode(200, "Account is Empty");
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
        [HttpGet("get-all-account")]
        public async Task<IActionResult> GetAllAccount(int id)
        {
            try
            {
                var account = await _accountRepository.GetAllAccount();
                if (account != null)
                {
                    return StatusCode(200, account);
                }
                else return StatusCode(200, "Account is Empty");
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
        [HttpPost("create-account")]
        public async Task<IActionResult> AddNewAccount(AccountRequest accountRequest)
        {
            try
            {
                var account = await _accountRepository.AddNewAccount(accountRequest);
                if (account != null)
                {
                    return StatusCode(200, "Create Account Successfully");
                }
                else return StatusCode(200, "Create Account Fail");
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
        [HttpPost("create-admin")]
        public async Task<IActionResult> AddNewAdminAccount(AccountRequest accountRequest)
        {
            try
            {
                var account = await _accountRepository.AddNewAccount(accountRequest);
                if (account != null)
                {
                    return StatusCode(200, "Create Account Successfully");
                }
                else return StatusCode(200, "Create Account Fail");
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
        [HttpPost("create-staff")]
        public async Task<IActionResult> AddNewStaffAccount(AccountRequest accountRequest)
        {
            try
            {
                var account = await _accountRepository.AddNewAccount(accountRequest);
                if (account != null)
                {
                    return StatusCode(200, "Create Account Successfully");
                }
                else return StatusCode(200, "Create Account Fail");
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
        [HttpPost("login-account")]
        public async Task<IActionResult> loginAccount(string email, string password)
        {
            try
            {
                var account = await _accountRepository.GetAccountByEmailAndPassword(email, password);
                if (account != null)
                {
                    var token = ProvideToken.Instance.GenerateToken(account);
                    return Ok(token);
                }
                else return StatusCode(200, "Account is Empty");
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
        [HttpPut("update-account")]
        public async Task<IActionResult> UpdateAccount(AccountRequest accountRequest)
        {
            try
            {
                var account = await _accountRepository.UpdateAccount(accountRequest);
                if (account != false)
                {
                    return StatusCode(200, "Update Account Successfully");
                }
                else return StatusCode(200, "Update Account Fail");
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
        [HttpDelete("delete-account")]
        public async Task<IActionResult> DeleteAccount(AccountRequest accountRequest)
        {
            try
            {
                var account = await _accountRepository.DeleteAccount(accountRequest);
                if (account != false)
                {
                    return StatusCode(200, "Delete Account Successfully");
                }
                else return StatusCode(200, "Delete Account Fail");
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
