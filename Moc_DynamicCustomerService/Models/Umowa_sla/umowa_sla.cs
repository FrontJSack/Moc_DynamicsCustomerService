using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Moc_DynamicCustomerService.Models;

namespace Moc_DynamicCustomerService.Models
{
    public class Umowa_sla
    {
        [Key]
        public int umowa_id { get; set; } // klucz główny

        [ForeignKey("Konto")]
        public int kontoId { get; set; } // klucz obcy

        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public int CzasReakcjiMin { get; set; }
        public int CzasRozwiazaniaMin { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }

        // Nawigacja do tabeli KONTO
        public Konto? Konto { get; set; } = null!;
    }
}