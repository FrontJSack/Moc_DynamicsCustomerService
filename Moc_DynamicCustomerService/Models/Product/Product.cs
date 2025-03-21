using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Moc_DynamicCustomerService.Models;

namespace Moc_DynamicCustomerService.Models;

    public enum ProductCategory
    {
        A,
        B,
        C,
        D
    }
    public class Products
    {
        public int Product_id { get; set; }
        public required string Name { get; set; }
        public ProductCategory Category { get; set;}
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Licenses>? Licenses { get; set; }
    }