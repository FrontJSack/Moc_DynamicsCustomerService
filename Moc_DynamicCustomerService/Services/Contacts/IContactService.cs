using Example.Models;

public interface IContactService
{
    Task<IEnumerable<Contacts>> GetAllAsync();
    Task<Contacts?> GetByIdAsync(int id);
    Task<Contacts> CreateAsync(Contacts newCase);
    Task<bool> UpdateAsync(int id, UpdateContact updatedContact);
    Task<bool> DeleteAsync(int id);
}
