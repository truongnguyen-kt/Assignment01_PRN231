using Assignment01.Utils.Request;
using Microsoft.AspNetCore.Mvc;
using Repository.IRepo;

namespace Assignment01.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
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
        [HttpPost("get-account-by-email-and-password")]
        public async Task<IActionResult> GetAccountByEmailAndPassword(AccountRequest accountRequest)
        {
            try
            {
                var account = await _accountRepository.GetAccountByEmailAndPassword(accountRequest.Email, accountRequest.Password);
                if (account != null)
                {
                    return StatusCode(200, "Get Account By Email and Password Successfully");
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
