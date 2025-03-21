using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace Moc_DynamicCustomerService.Endpoints;
public static class CaseEndpoints
{
    public static void MapCaseEndpoints(this WebApplication app)
    {
        var caseGroup = app.MapGroup("/cases");

        caseGroup.MapGet("/", async (AppDbContext context) =>
        {
            var cases = await context.Cases
                .Include(c => c.Contact)
                .Include(c => c.Account)
                .Include(c => c.User)
                .Include(c => c.Notes)
                .Include(c => c.Emails)
                .ToListAsync();
            return cases;
        });

        caseGroup.MapGet("/{id:int}", async (int id, AppDbContext context) =>
        {
            var caseItem = await context.Cases
                .Include(c => c.Contact)
                .Include(c => c.Account)
                .Include(c => c.User)
                .Include(c => c.Notes)
                .Include(c => c.Emails)
                .FirstOrDefaultAsync(c => c.Case_id == id);

            if (caseItem is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(caseItem);
        });

        caseGroup.MapPost("/", async (Cases caseItem, AppDbContext context) =>
        {
            context.Cases.Add(caseItem);
            await context.SaveChangesAsync();
            return Results.Created($"/cases/{caseItem.Case_id}", caseItem);
        });

        caseGroup.MapPatch("/{id:int}", async (int id, UpdateCase updatedCase, AppDbContext context) =>
        {
            var existingCase = await context.Cases.FindAsync(id);
            if (existingCase is null)
            {
                return Results.NotFound();
            }

            existingCase.Topic = updatedCase.Topic ?? existingCase.Topic;
            existingCase.Description = updatedCase.Description ?? existingCase.Description;
            existingCase.Status = updatedCase.Status ?? existingCase.Status;
            existingCase.Priority = updatedCase.Priority ?? existingCase.Priority;
            existingCase.DateClosed = updatedCase.DateClosed ?? existingCase.DateClosed;
            existingCase.DueDate = updatedCase.DueDate ?? existingCase.DueDate;

            await context.SaveChangesAsync();
            return Results.Ok(existingCase);
        });

        caseGroup.MapDelete("/{id:int}", async (int id, AppDbContext context) =>
        {
            var caseItem = await context.Cases.FindAsync(id);
            if (caseItem is null)
            {
                return Results.NotFound();
            }

            context.Cases.Remove(caseItem);
            await context.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
