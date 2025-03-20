using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace Moc_DynamicCustomerService.Endpoints;
public static class EmailEndpoints
{
    public static void MapEmailEndpoints(this WebApplication app)
    {
        var emailGroup = app.MapGroup("/emails");

        emailGroup.MapGet("/", async (AppDbContext context) =>
        {
            var emails = await context.Emails.ToListAsync();
            return emails;
        });

        emailGroup.MapGet("/{id:int}", async (int id, AppDbContext context) =>
        {
            var email = await context.Emails.FindAsync(id);
            return email is null ? Results.NotFound() : Results.Ok(email);
        });

        emailGroup.MapPost("/", async (Emails email, AppDbContext context) =>
        {
            context.Emails.Add(email);
            await context.SaveChangesAsync();
            return Results.Created($"/emails/{email.Email_id}", email);
        });

        emailGroup.MapPatch("/{id:int}", async (int id, Update_Email updatedEmail, AppDbContext context) =>
        {
            var existingEmail = await context.Emails.FindAsync(id);
            if (existingEmail is null) return Results.NotFound();

            existingEmail.Subject = updatedEmail.Subject;
            existingEmail.Content = updatedEmail.Content;

            await context.SaveChangesAsync();
            return Results.Ok(existingEmail);
        });

        emailGroup.MapDelete("/{id:int}", async (int id, AppDbContext context) =>
        {
            var email = await context.Emails.FindAsync(id);
            if (email is null) return Results.NotFound();

            context.Emails.Remove(email);
            await context.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
