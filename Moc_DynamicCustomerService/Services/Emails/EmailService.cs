using Example.Data;
using Example.Models;
using Microsoft.EntityFrameworkCore;


namespace Example.Services;
public class EmailService(AppDbContext context) : IEmailService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Emails>> GetAllAsync()
    {
        return await _context.Emails
            .Include(c => c.Cases)
            .ToListAsync();
    }

    public async Task<Emails?> GetByIdAsync(int id)
    {
        return await _context.Emails
            .Include(c => c.Cases)
            .FirstOrDefaultAsync(c => c.Email_id == id);
    }

    public async Task<Emails> CreateAsync(Emails newEmail)
    {
        _context.Emails.Add(newEmail);
        await _context.SaveChangesAsync();
        return newEmail;
    }

    public async Task<bool> UpdateAsync(int id, Update_Email updatedEmail)
    {
        var existingEmail = await _context.Emails.FindAsync(id);
        if (existingEmail == null) return false;

        // Aktualizacja tylko przekazanych pól
        existingEmail.Subject = updatedEmail.Subject ?? existingEmail.Subject;
        existingEmail.Content = updatedEmail.Content ?? existingEmail.Content;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingEmail = await _context.Emails.FindAsync(id);
        if (existingEmail == null) return false;

        _context.Emails.Remove(existingEmail);
        await _context.SaveChangesAsync();
        return true;
    }
}
