using System.ComponentModel.DataAnnotations;
using Moc_DynamicCustomerService.Models;

namespace Moc_DynamicCustomerService.Models;
    public class Sla_contracts
    {
        public int Sla_id { get; set; }
        public int AccountId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int minReactionTime { get; set; }
        public int minSolveTime { get; set; }
        public DateTime startDate { get; set; } = DateTime.Now;
        public DateTime endDate { get; set; }
        public Accounts? Account { get; set; }
    }