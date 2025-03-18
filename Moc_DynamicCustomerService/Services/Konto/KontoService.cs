using Microsoft.EntityFrameworkCore;
using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models.Konto;

namespace Moc_DynamicCustomerService.Services.KontoService
{
    public class KontoService
    {
        private readonly ApplicationDbContext _context;

        public KontoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Metoda do pobrania wszystkich kont
        public async Task<List<Konto>> GetAllKontaAsync()
        {
            return await _context.Konta.ToListAsync();
        }

        // Metoda do pobrania konta po ID
        public async Task<Konto> GetKontoByIdAsync(int id)
        {
            return await _context.Konta.FindAsync(id);
        }

        // Metoda do dodawania nowego konta
        public async Task<Konto> AddKontoAsync(Konto konto)
        {
            _context.Konta.Add(konto);
            await _context.SaveChangesAsync();
            return konto;
        }

        // Metoda do aktualizacji istniejącego konta
        public async Task<Konto> UpdateKontoAsync(int id, Konto konto)
        {
            var existingKonto = await _context.Konta.FindAsync(id);
            if (existingKonto == null) return null;

            existingKonto.nazwaFirmy = konto.nazwaFirmy;
            existingKonto.branza = konto.branza;
            existingKonto.nip = konto.nip;
            existingKonto.adres = konto.adres;
            existingKonto.miasto = konto.miasto;
            existingKonto.kraj = konto.kraj;
            existingKonto.emailGlowny = konto.emailGlowny;
            existingKonto.telefonGlowny = konto.telefonGlowny;
            existingKonto.dataModyfikacji = DateTime.Now;

            await _context.SaveChangesAsync();

            return existingKonto;
        }

        // Metoda do usuwania konta
        public async Task<bool> DeleteKontoAsync(int id)
        {
            var konto = await _context.Konta.FindAsync(id);
            if (konto == null) return false;

            _context.Konta.Remove(konto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
