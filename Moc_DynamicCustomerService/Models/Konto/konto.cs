using System;
using System.ComponentModel.DataAnnotations;

namespace Moc_DynamicCustomerService.Models
{
    public class Konto
    {
        [Key]
        public int kontoId { get; set; }

        public string nazwaFirmy { get; set; }
        public string branza { get; set; }
        public string nip { get; set; }
        public string adres { get; set; }
        public string miasto { get; set; }
        public string kraj { get; set; }
        public string emailGlowny { get; set; }
        public string telefonGlowny { get; set; }
        public DateTime dataUtworzenia { get; set; } = DateTime.Now;
        public DateTime dataModyfikacji { get; set; } = DateTime.Now;
    }
}