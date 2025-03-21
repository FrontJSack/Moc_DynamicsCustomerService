using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace Moc_DynamicCustomerService.Endpoints;
public static class ReportEndpoints
{
    public static void MapReportEndpoints(this WebApplication app)
    {
        var reportGroup = app.MapGroup("/reports");

        reportGroup.MapGet("/", async (AppDbContext context) =>
        {
            var reports = await context.Reports.ToListAsync();
            return reports;
        });

        reportGroup.MapGet("/{id:int}", async (int id, AppDbContext context) =>
        {
            var report = await context.Reports.FindAsync(id);
            return report is null ? Results.NotFound() : Results.Ok(report);
        });

        reportGroup.MapPost("/", async (Report report, AppDbContext context) =>
        {
            context.Reports.Add(report);
            await context.SaveChangesAsync();
            return Results.Created($"/reports/{report.Report_id}", report);
        });

        reportGroup.MapPatch("/{id:int}", async (int id, UpdateReport updatedReport, AppDbContext context) =>
        {
            var existingReport = await context.Reports.FindAsync(id);
            if (existingReport is null) return Results.NotFound();

            existingReport.Name = updatedReport.Name ?? existingReport.Name;
            existingReport.Type = updatedReport.Type ?? existingReport.Type;
            existingReport.Parameters = updatedReport.Parameters?.ToString() ?? existingReport.Parameters;

            await context.SaveChangesAsync();
            return Results.Ok(existingReport);
        });

        reportGroup.MapDelete("/{id:int}", async (int id, AppDbContext context) =>
        {
            var report = await context.Reports.FindAsync(id);
            if (report is null) return Results.NotFound();

            context.Reports.Remove(report);
            await context.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
