using System.ComponentModel.DataAnnotations;

namespace Example.Models
{

    public class Update_License
    {
        public int? AccountId { get; set; }
        public int? SeriesNumber { get; set; }
        public DateTime? EndDate { get; set; }
    }
}