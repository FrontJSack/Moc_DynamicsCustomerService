using System.Text.Json.Serialization;

namespace Moc_DynamicCustomerService.Models;



public class Contacts
{

    public int Contact_id { get; set; }
    public int? AccountId { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; } 
    [JsonIgnore]
    public Accounts? Account { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime? DateUpdated { get; set; }
    public ICollection<Cases>? Cases { get; set; }
}
