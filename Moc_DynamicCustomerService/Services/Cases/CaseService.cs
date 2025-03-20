using Example.Data;
using Example.Models;
using Microsoft.EntityFrameworkCore;


namespace Example.Services;
public class CaseService(AppDbContext context) : ICaseService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Cases>> GetAllAsync()
    {
        return await _context.Cases
            .Include(c => c.Contact)
            .Include(c => c.Account)
            .Include(c => c.User)
            .Include(c => c.Notes)
            .Include(c => c.Emails)
            .ToListAsync();
    }

    public async Task<Cases?> GetByIdAsync(int id)
    {
        return await _context.Cases
            .Include(c => c.Contact)
            .Include(c => c.Account)
            .Include(c => c.User)
            .Include(c => c.Notes)
            .Include(c => c.Emails)
            .FirstOrDefaultAsync(c => c.Case_id == id);
    }

    public async Task<Cases> CreateAsync(Cases newCase)
    {
        _context.Cases.Add(newCase);
        await _context.SaveChangesAsync();
        return newCase;
    }

    public async Task<bool> UpdateAsync(int id, UpdateCase updatedCase)
    {
        var existingCase = await _context.Cases.FindAsync(id);
        if (existingCase == null) return false;

        // Aktualizacja tylko przekazanych pól
        existingCase.Topic = updatedCase.Topic ?? existingCase.Topic;
        existingCase.Description = updatedCase.Description ?? existingCase.Description;
        if (updatedCase.Status.HasValue) existingCase.Status = updatedCase.Status.Value;
        if (updatedCase.Priority.HasValue) existingCase.Priority = updatedCase.Priority.Value;
        if (updatedCase.DueDate.HasValue) existingCase.DueDate = updatedCase.DueDate;
        if (updatedCase.Status == Status.Closed) existingCase.DateClosed = DateTime.Now;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingCase = await _context.Cases.FindAsync(id);
        if (existingCase == null) return false;

        _context.Cases.Remove(existingCase);
        await _context.SaveChangesAsync();
        return true;
    }
}
