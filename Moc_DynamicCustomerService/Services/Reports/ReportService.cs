using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;


namespace Moc_DynamicCustomerService.Services;
public class ReportService(AppDbContext context) : IReportService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Report>> GetAllAsync()
    {
        return await _context.Reports
            .Include(c => c.User)
            .ToListAsync();
    }

    public async Task<Report?> GetByIdAsync(int id)
    {
        return await _context.Reports
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.Report_id == id);
    }

    public async Task<Report> CreateAsync(Report newReport)
    {
        _context.Reports.Add(newReport);
        await _context.SaveChangesAsync();
        return newReport;
    }

    public async Task<bool> UpdateAsync(int id, UpdateReport updatedReport)
    {
        var existingReport = await _context.Reports.FindAsync(id);
        if (existingReport == null) return false;

        // Aktualizacja tylko przekazanych pól
        existingReport.Name = updatedReport.Name ?? existingReport.Name;
        existingReport.Type = updatedReport.Type ?? existingReport.Type;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingReport = await _context.Reports.FindAsync(id);
        if (existingReport == null) return false;

        _context.Reports.Remove(existingReport);
        await _context.SaveChangesAsync();
        return true;
    }
}
