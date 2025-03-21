using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace Moc_DynamicCustomerService.Endpoints
{
    public static class SlaContractEndpoints
    {
        public static void MapSlaContractEndpoints(this WebApplication app)
        {
            var slaContractGroup = app.MapGroup("/sla-contracts");

            // Endpoint do pobrania wszystkich SLA
            slaContractGroup.MapGet("/", async (AppDbContext context) =>
            {
                var slaContracts = await context.Sla_contracts
                    .Include(s => s.Account)
                    .ToListAsync();
                return slaContracts;
            });

            // Endpoint do pobrania SLA po ID
            slaContractGroup.MapGet("/{id:int}", async (int id, AppDbContext context) =>
            {
                var slaContract = await context.Sla_contracts
                    .Include(s => s.Account)
                    .FirstOrDefaultAsync(s => s.Sla_id == id);
                if (slaContract is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(slaContract);
            });

            // Endpoint do dodania nowego SLA
            slaContractGroup.MapPost("/", async (Sla_contracts slaContract, AppDbContext context) =>
            {
                context.Sla_contracts.Add(slaContract);
                await context.SaveChangesAsync();
                return Results.Created($"/sla-contracts/{slaContract.Sla_id}", slaContract);
            });

            // Endpoint do aktualizacji SLA
            slaContractGroup.MapPatch("/{id:int}", async (int id, Update_sla updatedSla, AppDbContext context) =>
            {
                var existingSla = await context.Sla_contracts.FindAsync(id);
                if (existingSla is null)
                {
                    return Results.NotFound();
                }

                // Aktualizacja tylko przekazanych pól
                existingSla.AccountId = updatedSla.AccountId ?? existingSla.AccountId;
                existingSla.Name = updatedSla.Name ?? existingSla.Name;
                existingSla.Description = updatedSla.Description ?? existingSla.Description;
                if (updatedSla.minReactionTime.HasValue) existingSla.minReactionTime = updatedSla.minReactionTime.Value;
                if (updatedSla.minSolveTime.HasValue) existingSla.minSolveTime = updatedSla.minSolveTime.Value;
                if (updatedSla.endDate.HasValue) existingSla.endDate = updatedSla.endDate.Value;

                await context.SaveChangesAsync();
                return Results.Ok(existingSla);
            });

            // Endpoint do usunięcia SLA
            slaContractGroup.MapDelete("/{id:int}", async (int id, AppDbContext context) =>
            {
                var slaContract = await context.Sla_contracts.FindAsync(id);
                if (slaContract is null)
                {
                    return Results.NotFound();
                }

                context.Sla_contracts.Remove(slaContract);
                await context.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
