using System.ComponentModel.DataAnnotations;
using Example.Models;

namespace Example.Models;

    public class Emails
    {
        public int Email_id { get; set; }
        public int CaseId { get; set; }
        public required string Sender { get; set; }
        public required string Recipient { get; set; }
        public required string Subject { get; set; }
        public required string Content { get; set; }
        public DateTime SendDate { get; set; } = DateTime.Now;
        public Cases? Cases { get; set; }
}