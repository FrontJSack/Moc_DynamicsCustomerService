using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;


namespace Moc_DynamicCustomerService.Services;
public class NoteService(AppDbContext context) : INoteService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Notes>> GetAllAsync()
    {
        return await _context.Notes
            .Include(c => c.Case)
            .Include(c => c.User)
            .ToListAsync();
    }

    public async Task<Notes?> GetByIdAsync(int id)
    {
        return await _context.Notes
            .Include(c => c.Case)
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.Note_id == id);
    }

    public async Task<Notes> CreateAsync(Notes newNote)
    {
        _context.Notes.Add(newNote);
        await _context.SaveChangesAsync();
        return newNote;
    }

    public async Task<bool> UpdateAsync(int id, UpdateNote updatedNote)
    {
        var existingNote = await _context.Notes.FindAsync(id);
        if (existingNote == null) return false;

        // Aktualizacja tylko przekazanych pól
        existingNote.Content = updatedNote.Content ?? existingNote.Content;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingNote = await _context.Notes.FindAsync(id);
        if (existingNote == null) return false;

        _context.Notes.Remove(existingNote);
        await _context.SaveChangesAsync();
        return true;
    }
}
