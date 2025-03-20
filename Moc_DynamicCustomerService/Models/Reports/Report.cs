using System.Text.Json.Serialization;

namespace Moc_DynamicCustomerService.Models;

public class Report
{
    public int Report_id { get; set; }
    public int UserId { get; set; }
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string Parameters { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    [JsonIgnore]
    public Users? User { get; set; }
}