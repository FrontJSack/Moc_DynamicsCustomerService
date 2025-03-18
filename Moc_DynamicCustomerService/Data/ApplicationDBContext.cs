using Microsoft.EntityFrameworkCore;
using Moc_DynamicCustomerService.Models.Konto;


namespace Moc_DynamicCustomerService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Konto> Konta { get; set; } // Jeśli masz model Konto
    }
}
