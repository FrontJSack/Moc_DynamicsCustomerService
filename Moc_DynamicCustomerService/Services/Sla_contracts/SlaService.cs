using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;


namespace Moc_DynamicCustomerService.Services;
public class SlaService(AppDbContext context) : ISlaService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Sla_contracts>> GetAllAsync()
    {
        return await _context.Sla_contracts
            .Include(c => c.Account)
            .ToListAsync();
    }

    public async Task<Sla_contracts?> GetByIdAsync(int id)
    {
        return await _context.Sla_contracts
            .Include(c => c.Account)
            .FirstOrDefaultAsync(c => c.Sla_id == id);
    }

    public async Task<Sla_contracts> CreateAsync(Sla_contracts newSla_contract)
    {
        _context.Sla_contracts.Add(newSla_contract);
        await _context.SaveChangesAsync();
        return newSla_contract;
    }

    public async Task<bool> UpdateAsync(int id, Update_sla updatedSla_contract)
    {
        var existingSla_contract = await _context.Sla_contracts.FindAsync(id);
        if (existingSla_contract == null) return false;

        // Aktualizacja tylko przekazanych pól
        existingSla_contract.AccountId = updatedSla_contract.AccountId ?? existingSla_contract.AccountId;
        existingSla_contract.Description = updatedSla_contract.Description ?? existingSla_contract.Description;
        existingSla_contract.Name = updatedSla_contract.Name ?? existingSla_contract.Name;
        existingSla_contract.minReactionTime = updatedSla_contract.minReactionTime ?? existingSla_contract.minReactionTime;
        existingSla_contract.minSolveTime = updatedSla_contract.minSolveTime ?? existingSla_contract.minSolveTime;
        existingSla_contract.endDate = updatedSla_contract.endDate ?? existingSla_contract.endDate;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingSla_contract = await _context.Sla_contracts.FindAsync(id);
        if (existingSla_contract == null) return false;

        _context.Sla_contracts.Remove(existingSla_contract);
        await _context.SaveChangesAsync();
        return true;
    }
}
