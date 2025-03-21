using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Moc_DynamicCustomerService.Models;

namespace Moc_DynamicCustomerService.Models;
    public class Licenses
    {
        public int License_id { get; set; }
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public int SeriesNumber { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        [JsonIgnore]
        public Accounts? Account { get; set; }
        [JsonIgnore]
        public Products? Products { get; set; }
    }