using System.ComponentModel.DataAnnotations;

namespace Example.Models
{

    public class Update_User
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Login { get; set; }
        public string? Role { get; set; }
    }
}