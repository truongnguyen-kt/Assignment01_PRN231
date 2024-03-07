using Assignment01.Utils.Request;
using Assignment01.Utils.Response;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepo
{
    public interface IAccountRepository
    {
        public Task<bool> AddNewAccount(AccountRequest accountRequest);
        public Task<bool> AddNewStaffAccount(AccountRequest accountRequest);
        public Task<bool> AddNewAdminAccount(AccountRequest accountRequest);
        public Task<bool> UpdateAccount(AccountRequest accountRequest);
        public Task<bool> DeleteAccount(AccountRequest accountRequest);
        public Task<Account> GetAccountById(int id);
        public Task<List<Account>> GetAllAccount();
        public Task<Account> GetAccountByEmail(string email);
        public Task<Account> GetAccountByEmailAndPassword(string email, string password);
        public Task<AccountResponse> ConvertToResponse(Account account);
    }
}
