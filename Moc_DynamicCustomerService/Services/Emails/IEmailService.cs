using Moc_DynamicCustomerService.Models;

public interface IEmailService
{
    Task<IEnumerable<Emails>> GetAllAsync();
    Task<Emails?> GetByIdAsync(int id);
    Task<Emails> CreateAsync(Emails newEmail);
    Task<bool> UpdateAsync(int id, Update_Email updatedEmail);
    Task<bool> DeleteAsync(int id);
}
