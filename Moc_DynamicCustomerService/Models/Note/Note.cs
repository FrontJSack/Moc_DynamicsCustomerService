using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Moc_DynamicCustomerService.Models;

namespace Moc_DynamicCustomerService.Models;

    public class Notes
    {
        public int Note_id { get; set; }
        public int CaseId { get; set; }
        public int UserId { get; set; }
        public required string Content { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [JsonIgnore]
        public Cases? Case { get; set; }
        [JsonIgnore]
        public Users? User { get; set; }
}