using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;


namespace Moc_DynamicCustomerService.Services;
public class ContactService(AppDbContext context) : IContactService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Contacts>> GetAllAsync()
    {
        return await _context.Contacts
            .Include(c => c.Account)
            .Include(c => c.Cases)
            .ToListAsync();
    }

    public async Task<Contacts?> GetByIdAsync(int id)
    {
        return await _context.Contacts
            .Include(c => c.Account)
            .Include(c => c.Cases)
            .FirstOrDefaultAsync(c => c.Contact_id == id);
    }

    public async Task<Contacts> CreateAsync(Contacts newContact)
    {
        _context.Contacts.Add(newContact);
        await _context.SaveChangesAsync();
        return newContact;
    }

    public async Task<bool> UpdateAsync(int id, UpdateContact updatedContact)
    {
        var existingContact = await _context.Contacts.FindAsync(id);
        if (existingContact == null) return false;

        // Aktualizacja tylko przekazanych pól
        existingContact.Name = updatedContact.Name ?? existingContact.Name;
        existingContact.LastName = updatedContact.LastName ?? existingContact.LastName;
        existingContact.Email = updatedContact.Email ?? existingContact.Email;
        existingContact.Phone = updatedContact.Phone ?? existingContact.Phone;
        existingContact.AccountId = updatedContact.AccountId ?? existingContact.AccountId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingContact = await _context.Contacts.FindAsync(id);
        if (existingContact == null) return false;

        _context.Contacts.Remove(existingContact);
        await _context.SaveChangesAsync();
        return true;
    }
}
