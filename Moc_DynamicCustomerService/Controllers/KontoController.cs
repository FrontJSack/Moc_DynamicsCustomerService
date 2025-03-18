using Microsoft.AspNetCore.Mvc;
using Moc_DynamicCustomerService.Models.Konto;
using Moc_DynamicCustomerService.Services.KontoService;

namespace Moc_DynamicCustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontoController : ControllerBase
    {
        private readonly KontoService _kontoService;

        public KontoController(KontoService kontoService)
        {
            _kontoService = kontoService;
        }

        // GET: api/Konto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Konto>>> GetKonta()
        {
            var konta = await _kontoService.GetAllKontaAsync();
            return Ok(konta);
        }

        // GET: api/Konto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Konto>> GetKonto(int id)
        {
            var konto = await _kontoService.GetKontoByIdAsync(id);

            if (konto == null)
            {
                return NotFound();
            }

            return Ok(konto);
        }

        // POST: api/Konto
        [HttpPost]
        public async Task<ActionResult<Konto>> PostKonto(Konto konto)
        {
            var createdKonto = await _kontoService.AddKontoAsync(konto);
            return CreatedAtAction("GetKonto", new { id = createdKonto.kontoId }, createdKonto);
        }

        // PATCH: api/Konto/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PutKonto(int id, Konto konto)
        {
            var updatedKonto = await _kontoService.UpdateKontoAsync(id, konto);
            if (updatedKonto == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Konto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKonto(int id)
        {
            var success = await _kontoService.DeleteKontoAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
