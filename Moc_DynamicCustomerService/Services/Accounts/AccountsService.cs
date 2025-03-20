//CRUD dla Accounts
// Compare this snippet from Services/Accounts/AccountsService.cs:

using Example.Services;
using Example.Models;
using Microsoft.EntityFrameworkCore;
using Example.Data;

namespace Example.Services
{
    public class AccountsService(AppDbContext context) : IAccountsService
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<Accounts>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Accounts?> GetByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Accounts> CreateAsync(Accounts account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return false;
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Accounts> UpdateAsync(int id, UpdateAccount dto)
        {
            var account = await _context.Accounts.FindAsync(id) ?? throw new Exception("Account not found");
            account.Industry = dto.Industry ?? account.Industry;
            account.Nip = dto.Nip ?? account.Nip;
            account.Address = dto.Address ?? account.Address;
            account.City = dto.City ?? account.City;
            account.Country = dto.Country ?? account.Country;
            account.MainEmail = dto.MainEmail ?? account.MainEmail;
            account.MainPhone = dto.MainPhone ?? account.MainPhone;
            account.DateUpdated = DateTime.Now;

            await _context.SaveChangesAsync();
            return account;
        }
    }
}