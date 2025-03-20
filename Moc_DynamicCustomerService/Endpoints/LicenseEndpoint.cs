using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace Moc_DynamicCustomerService.Endpoints;
public static class LicenseEndpoints
{
    public static void MapLicenseEndpoints(this WebApplication app)
    {
        var licenseGroup = app.MapGroup("/licenses");

        licenseGroup.MapGet("/", async (AppDbContext context) =>
        {
            var licenses = await context.Licenses.ToListAsync();
            return licenses;
        });

        licenseGroup.MapGet("/{id:int}", async (int id, AppDbContext context) =>
        {
            var license = await context.Licenses.FindAsync(id);
            return license is null ? Results.NotFound() : Results.Ok(license);
        });

        licenseGroup.MapPost("/", async (Licenses license, AppDbContext context) =>
        {
            context.Licenses.Add(license);
            await context.SaveChangesAsync();
            return Results.Created($"/licenses/{license.License_id}", license);
        });

        licenseGroup.MapPatch("/{id:int}", async (int id, Update_License updatedLicense, AppDbContext context) =>
        {
            var existingLicense = await context.Licenses.FindAsync(id);
            if (existingLicense is null) return Results.NotFound();

            existingLicense.AccountId = updatedLicense.AccountId ?? existingLicense.AccountId;
            existingLicense.SeriesNumber = updatedLicense.SeriesNumber ?? existingLicense.SeriesNumber;
            existingLicense.EndDate = updatedLicense.EndDate ?? existingLicense.EndDate;

            await context.SaveChangesAsync();
            return Results.Ok(existingLicense);
        });

        licenseGroup.MapDelete("/{id:int}", async (int id, AppDbContext context) =>
        {
            var license = await context.Licenses.FindAsync(id);
            if (license is null) return Results.NotFound();

            context.Licenses.Remove(license);
            await context.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
