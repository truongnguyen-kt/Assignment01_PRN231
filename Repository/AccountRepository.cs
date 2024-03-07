using Assignment01.Utils.Request;
using Assignment01.Utils.Response;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly assignment_prn_231Context _context;
        private readonly IRoleRepository _roleRepository;
        public AccountRepository(assignment_prn_231Context context)
        {
            _context = context;
        }
        public AccountRepository(assignment_prn_231Context context, IRoleRepository roleRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
        }
        public async Task<bool> AddNewAccount(AccountRequest accountRequest)
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
                var account = await GetAccountByEmail(accountRequest.Email);
                if (account != null)
                {
                    throw new Exception("Email already exist!");
                }
                var role = await _roleRepository.GetRoleByName("User");
                await _context.Accounts.AddAsync(
                    new Account
                    {
                        Email = accountRequest.Email,
                        Password = accountRequest.Password,
                        FullName = accountRequest.FullName,
                        Address = accountRequest.Address,
                        DateOfBirth = accountRequest.DateOfBirth,
                        Status = true,
                        RoleId = role.Id
                    }
                ); ;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddNewStaffAccount(AccountRequest accountRequest)
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
                var account = await GetAccountByEmail(accountRequest.Email);
                if (account != null)
                {
                    throw new Exception("Email already exist!");
                }
                var role = await _roleRepository.GetRoleByName("Staff");
                await _context.Accounts.AddAsync(
                    new Account
                    {
                        Email = accountRequest.Email,
                        Password = accountRequest.Password,
                        FullName = accountRequest.FullName,
                        Address = accountRequest.Address,
                        DateOfBirth = accountRequest.DateOfBirth,
                        Status = true,
                        RoleId = role.Id
                    }
                ); ;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddNewAdminAccount(AccountRequest accountRequest)
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
                var account = await GetAccountByEmail(accountRequest.Email);
                if (account != null)
                {
                    throw new Exception("Email already exist!");
                }
                var role = await _roleRepository.GetRoleByName("Admin");
                await _context.Accounts.AddAsync(
                    new Account
                    {
                        Email = accountRequest.Email,
                        Password = accountRequest.Password,
                        FullName = accountRequest.FullName,
                        Address = accountRequest.Address,
                        DateOfBirth = accountRequest.DateOfBirth,
                        Status = true,
                        RoleId = role.Id
                    }
                ); ;
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAccount(AccountRequest accountRequest)
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
            Account account = await GetAccountById(id);
            if (account == null)
            {
                throw new KeyNotFoundException(nameof(id));
            }
            account.Address = accountRequest.Address;
            account.Password = accountRequest.Password;
            account.FullName = accountRequest.FullName;
            account.DateOfBirth = accountRequest.DateOfBirth;
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAccount(AccountRequest accountRequest)
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
            Account account = await GetAccountById(id);
            if (account == null)
            {
                throw new KeyNotFoundException(nameof(id));
            }
            account.Status = false;
            _context.Accounts.Update(account);
            return true;
        }

        public async Task<Account> GetAccountById(int id)
        {
            if (id == null)
            {
                throw new MissingFieldException(nameof(id));
            }
            Account account = await _context.Accounts.FindAsync(id);
            return account;
        }

        public async Task<List<Account>> GetAllAccount()
        {
            return await _context.Accounts.ToListAsync();
        }
        public async Task<Account> GetAccountByEmail(string email)
        {
            if (email == null)
            {
                throw new MissingFieldException(nameof(email));
            }
            Account account = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == email);
            return account;
        }

        public async Task<Account> GetAccountByEmailAndPassword(string email, string password)
        {
            if (email == null)
            {
                throw new MissingFieldException(nameof(email));
            }
            if (password == null)
            {
                throw new MissingFieldException(nameof(password));
            }
            Account account = await _context.Accounts.FirstOrDefaultAsync(
                x => (x.Email == email && x.Password == password && x.Status == true)
            );
            return account;
        }

        public async Task<AccountResponse> ConvertToResponse(Account account)
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
                Address = account.Address,
                Status = account.Status,
                Role = await _roleRepository.GetRoleById((int)account.RoleId)
            };
        }
    }
}

