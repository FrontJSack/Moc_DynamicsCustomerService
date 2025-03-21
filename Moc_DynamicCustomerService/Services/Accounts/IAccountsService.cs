using Moc_DynamicCustomerService.Models;

namespace Moc_DynamicCustomerService.Services;

public interface IAccountsService
{
    Task<IEnumerable<Accounts>> GetAllAsync();
    Task<Accounts?> GetByIdAsync(int id);
    Task<Accounts> CreateAsync(Accounts contact);
    Task<bool> DeleteAsync(int id);
    Task<Accounts> UpdateAsync(int id, UpdateAccount dto);
}