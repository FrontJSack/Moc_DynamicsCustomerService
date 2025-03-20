using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Example.Models;

[Index(nameof(CompanyName), IsUnique = true)]
public class Accounts
{
    public int Account_id { get; set; }
    public required string CompanyName { get; set; }
    public string? Industry { get; set; }
    public string? Nip { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? MainEmail { get; set; }
    public string? MainPhone { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime DateUpdated { get; set; } 
        [JsonIgnore]
    public ICollection<Contacts>? Contacts { get; set; }
        [JsonIgnore]
    public ICollection<Cases>? Cases { get; set; }
    [JsonIgnore]
    public ICollection<Sla_contracts>? Sla_contracts { get; set; }
        [JsonIgnore]
    public ICollection<Licenses>? Licenses { get; set; }
}
