using System.ComponentModel.DataAnnotations;

namespace Example.Models
{

    public class Update_Email
    {
        public required string Subject { get; set; }
        public required string Content { get; set; }
    }
}