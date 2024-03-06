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
        public bool AddNewAccount(AccountRequest accountRequest);
        public bool UpdateAccount(AccountRequest accountRequest);
        public bool DeleteAccount(AccountRequest accountRequest);
        public Account GetAccountById(int id);
        public Account GetAccountByEmail(string email);
        public Account GetAccountByEmailAndPassword(string email, string password);
        public AccountResponse ConvertToResponse(Account account);
    }
}
