using Microsoft.EntityFrameworkCore;
using Moc_DynamicCustomerService.Models;

namespace Moc_DynamicCustomerService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Konto> Konta { get; set; } // Jeśli masz model Konto
        public DbSet<Umowa_sla> UmowySla { get; set; } // Model UmowaSla
        public DbSet<Kontakt> Kontakty { get; set; } // Model kontaktów
    }
}
