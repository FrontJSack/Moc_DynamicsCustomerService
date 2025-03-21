using System.ComponentModel.DataAnnotations;
using Moc_DynamicCustomerService.Models;

namespace Moc_DynamicCustomerService.Models;

    public class Users
    {
        public int User_id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Login { get; set; }
        public required string Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Cases>? Case { get; set; }
        public ICollection<Notes>? Notes { get; set; }
        public ICollection<Report>? Reports { get; set; }

}