using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;


namespace Moc_DynamicCustomerService.Services;
public class LicenseService(AppDbContext context) : ILicenseService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Licenses>> GetAllAsync()
    {
        return await _context.Licenses
            .Include(c => c.Products)
            .Include(c => c.Account)
            .ToListAsync();
    }

    public async Task<Licenses?> GetByIdAsync(int id)
    {
        return await _context.Licenses
            .Include(c => c.Products)
            .Include(c => c.Account)
            .FirstOrDefaultAsync(c => c.License_id == id);
    }

    public async Task<Licenses> CreateAsync(Licenses newLicense)
    {
        _context.Licenses.Add(newLicense);
        await _context.SaveChangesAsync();
        return newLicense;
    }

    public async Task<bool> UpdateAsync(int id, Update_License updatedLicense)
    {
        var existingLicense = await _context.Licenses.FindAsync(id);
        if (existingLicense == null) return false;

        // Aktualizacja tylko przekazanych pól
        existingLicense.AccountId = updatedLicense.AccountId ?? existingLicense.AccountId;
        existingLicense.SeriesNumber = updatedLicense.SeriesNumber ?? existingLicense.SeriesNumber;
        existingLicense.EndDate = updatedLicense.EndDate ?? existingLicense.EndDate;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingLicense = await _context.Licenses.FindAsync(id);
        if (existingLicense == null) return false;

        _context.Licenses.Remove(existingLicense);
        await _context.SaveChangesAsync();
        return true;
    }
}
