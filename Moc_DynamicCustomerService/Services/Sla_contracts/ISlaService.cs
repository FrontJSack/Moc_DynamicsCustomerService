using Moc_DynamicCustomerService.Models;

public interface ISlaService
{
    Task<IEnumerable<Sla_contracts>> GetAllAsync();
    Task<Sla_contracts?> GetByIdAsync(int id);
    Task<Sla_contracts> CreateAsync(Sla_contracts newSla_contract);
    Task<bool> UpdateAsync(int id, Update_sla updatedSla_contract);
    Task<bool> DeleteAsync(int id);
}
