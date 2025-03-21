using Moc_DynamicCustomerService.Models;

public interface IReportService
{
    Task<IEnumerable<Report>> GetAllAsync();
    Task<Report?> GetByIdAsync(int id);
    Task<Report> CreateAsync(Report newReport);
    Task<bool> UpdateAsync(int id, UpdateReport updatedReport);
    Task<bool> DeleteAsync(int id);
}
