using System.ComponentModel.DataAnnotations;
using Example.Models;

namespace Example.Models;

    public class Notes
    {
        public int Note_id { get; set; }
        public int CaseId { get; set; }
        public int UserId { get; set; }
        public required string Content { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public Cases? Case { get; set; }
        public Users? User { get; set; }
}