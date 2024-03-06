using Assignment01.Utils.Request;
using Assignment01.Utils.Response;
using DataAccess.Context;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01.Repository
{
    public class AccountRepository
    {
        private readonly assignment_prn_231Context _context;
        public AccountRepository(assignment_prn_231Context context)
        {
            _context = context;
        }
        public bool AddNewAccount(AccountRequest accountRequest)
        {
            if (accountRequest == null)
            {
                throw new ArgumentNullException("Account Request is Null!");
            }
            if (accountRequest.Email == null || accountRequest.Email.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(accountRequest.Email));
            }
            if (accountRequest.Password == null || accountRequest.Password.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(accountRequest.Password));
            }
            if (accountRequest.FullName == null || accountRequest.FullName.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(accountRequest.FullName));
            }
            if (accountRequest.DateOfBirth == null)
            {
                throw new MissingFieldException(nameof(accountRequest.DateOfBirth));
            }
            if (accountRequest.Address == null || accountRequest.Address.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(accountRequest.Address));
            }
            try
            {
                _context.Accounts.AddAsync(
                    new Account
                    {
                        Email = accountRequest.Email,
                        Password = accountRequest.Password,
                        FullName = accountRequest.FullName,
                        Address = accountRequest.Address,
                        DateOfBirth = accountRequest.DateOfBirth,
                    }
                );
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAccount(AccountRequest accountRequest)
        {
            if (accountRequest == null)
            {
                throw new ArgumentNullException("Account Request is Null!");
            }
            if (accountRequest.Id == null)
            {
                throw new MissingFieldException(nameof(accountRequest.Id));
            }
            if (accountRequest.Email == null || accountRequest.Email.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(accountRequest.Email));
            }
            if (accountRequest.Password == null || accountRequest.Password.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(accountRequest.Password));
            }
            if (accountRequest.FullName == null || accountRequest.FullName.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(accountRequest.FullName));
            }
            if (accountRequest.DateOfBirth == null)
            {
                throw new MissingFieldException(nameof(accountRequest.DateOfBirth));
            }
            if (accountRequest.Address == null || accountRequest.Address.Trim().Length < 1)
            {
                throw new MissingFieldException(nameof(accountRequest.Address));
            }

            int id = accountRequest.Id;
            Account account = GetAccountById(id);
            if (account == null)
            {
                throw new KeyNotFoundException(nameof(id));
            }
            _context.Accounts.Update(account);
            return true;
        }

        public bool DeleteAccount(AccountRequest accountRequest)
        {
            if (accountRequest == null)
            {
                throw new ArgumentNullException("Account Request is Null!");
            }
            if (accountRequest.Id == null)
            {
                throw new MissingFieldException(nameof(accountRequest.Id));
            }
            int id = accountRequest.Id;
            Account account = GetAccountById(id);
            if (account == null)
            {
                throw new KeyNotFoundException(nameof(id));
            }
            _context.Accounts.Remove(account);
            return true;
        }

        public Account GetAccountById(int id)
        {
            if (id == null)
            {
                throw new MissingFieldException(nameof(id));
            }
            Account account = _context.Accounts.FirstOrDefault(x => x.Id == id);
            return account;
        }

        public Account GetAccountByEmail(string email)
        {
            if (email == null)
            {
                throw new MissingFieldException(nameof(email));
            }
            Account account = _context.Accounts.FirstOrDefault(x => x.Email == email);
            return account;
        }

        public Account GetAccountByEmailAndPassword(string email, string password)
        {
            if (email == null)
            {
                throw new MissingFieldException(nameof(email));
            }
            if (password == null)
            {
                throw new MissingFieldException(nameof(password));
            }
            Account account = _context.Accounts.FirstOrDefault(
                x => (x.Email == email && x.Password == password)
            );
            return account;
        }

        public AccountResponse ConvertToResponse(Account account)
        {
            if (account == null)
            {
                return null;
            }
            return new AccountResponse
            {
                Id = account.Id,
                Email = account.Email,
                Password = account.Password,
                FullName = account.FullName,
                DateOfBirth = account.DateOfBirth,
                Address = account.Address
            };
        }
    }
}

