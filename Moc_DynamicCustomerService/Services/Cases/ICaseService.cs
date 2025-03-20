using Example.Models;

public interface ICaseService
{
    Task<IEnumerable<Cases>> GetAllAsync();
    Task<Cases?> GetByIdAsync(int id);
    Task<Cases> CreateAsync(Cases newCase);
    Task<bool> UpdateAsync(int id, UpdateCase updatedCase);
    Task<bool> DeleteAsync(int id);
}
