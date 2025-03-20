using System.ComponentModel.DataAnnotations;

namespace Moc_DynamicCustomerService.Models
{

    public class Update_License
    {
        public int? AccountId { get; set; }
        public int? SeriesNumber { get; set; }
        public DateTime? EndDate { get; set; }
    }
}