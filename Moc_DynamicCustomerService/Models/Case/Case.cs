using System.Text.Json.Serialization;

namespace Moc_DynamicCustomerService.Models;


public enum Status {
    Open,
    Closed
}

public enum Priority {
    Low,
    Medium,
    High
}
public class Cases
{
    public int Case_id { get; set; }
    public int ContactId { get; set; }
    public int AccountId { get; set; }
    public int UserId { get; set; }
    public string? Topic { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
    public Priority Priority { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime? DateClosed { get; set; }
    public DateTime? DueDate { get; set; }
    public Contacts? Contact { get; set; }
    public Accounts? Account { get; set; }
    public Users? User { get; set; }
        [JsonIgnore]
    public ICollection<Notes>? Notes { get; set; }
        [JsonIgnore]
    public ICollection<Emails>? Emails { get; set;}
}