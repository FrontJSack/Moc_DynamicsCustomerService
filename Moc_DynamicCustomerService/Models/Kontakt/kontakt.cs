using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Moc_DynamicCustomerService.Models;

namespace Moc_DynamicCustomerService.Models
{
    public class Kontakt
    {
        [Key]
        public int kontaktId { get; set; }

        [ForeignKey("Konto")]
        public int kontoId { get; set; }

        public Konto Konto { get; set; }

        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public DateTime data_utworzenia { get; set; } = DateTime.Now;
        public DateTime data_modyfikacji { get; set; } = DateTime.Now;

    }
}