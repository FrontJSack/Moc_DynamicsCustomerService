using Moc_DynamicCustomerService.Models;

public interface INoteService
{
    Task<IEnumerable<Notes>> GetAllAsync();
    Task<Notes?> GetByIdAsync(int id);
    Task<Notes> CreateAsync(Notes newNote);
    Task<bool> UpdateAsync(int id, UpdateNote updatedNote);
    Task<bool> DeleteAsync(int id);
}
