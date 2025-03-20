using Example.Models;

public interface ILicenseService
{
    Task<IEnumerable<Licenses>> GetAllAsync();
    Task<Licenses?> GetByIdAsync(int id);
    Task<Licenses> CreateAsync(Licenses newLicense);
    Task<bool> UpdateAsync(int id, Update_License updatedLicense);
    Task<bool> DeleteAsync(int id);
}
