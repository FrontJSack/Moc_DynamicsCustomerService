using System.ComponentModel.DataAnnotations;

namespace Moc_DynamicCustomerService.Models
{

    public class Update_sla
    {

        public int? AccountId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? minReactionTime { get; set; }

        public int? minSolveTime { get; set; }

        public DateTime? endDate { get; set; }

    }
}