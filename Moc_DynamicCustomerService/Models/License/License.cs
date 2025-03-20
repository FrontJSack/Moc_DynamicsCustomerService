using System.ComponentModel.DataAnnotations;
using Example.Models;

namespace Example.Models;
    public class Licenses
    {
        public int License_id { get; set; }
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public int SeriesNumber { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public Accounts? Account { get; set; }
        public Products? Products { get; set; }
    }