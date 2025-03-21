using System.ComponentModel.DataAnnotations;

namespace Moc_DynamicCustomerService.Models
{

    public class Update_Email
    {
        public required string Subject { get; set; }
        public required string Content { get; set; }
    }
}