using System.ComponentModel.DataAnnotations;

namespace Example.Models
{

    public class Update_Product
    {
        public string? Name { get; set; }

        public ProductCategory? Category { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}