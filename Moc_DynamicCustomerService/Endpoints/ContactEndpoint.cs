using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace Moc_DynamicCustomerService.Endpoints;
public static class ContactEndpoints
{
    public static void MapContactEndpoints(this WebApplication app)
    {
        var contactGroup = app.MapGroup("/contacts");

        contactGroup.MapGet("/", async (AppDbContext context) =>
        {
            var contacts = await context.Contacts
                .Include(c => c.Account)
                .Include(c => c.Cases)
                .ToListAsync();
            return contacts;
        });

        contactGroup.MapGet("/{id:int}", async (int id, AppDbContext context) =>
        {
            var contact = await context.Contacts
                .Include(c => c.Account)
                .Include(c => c.Cases)
                .FirstOrDefaultAsync(c => c.Contact_id == id);
            return contact is null ? Results.NotFound() : Results.Ok(contact);
        });

        contactGroup.MapPost("/", async (Contacts contact, AppDbContext context) =>
        {
            context.Contacts.Add(contact);
            await context.SaveChangesAsync();
            return Results.Created($"/contacts/{contact.Contact_id}", contact);
        });

        contactGroup.MapPatch("/{id:int}", async (int id, UpdateContact updatedContact, AppDbContext context) =>
        {
            var existingContact = await context.Contacts.FindAsync(id);
            if (existingContact is null) return Results.NotFound();

            existingContact.Name = updatedContact.Name ?? existingContact.Name;
            existingContact.LastName = updatedContact.LastName ?? existingContact.LastName;
            existingContact.Email = updatedContact.Email ?? existingContact.Email;
            existingContact.Phone = updatedContact.Phone ?? existingContact.Phone;
            existingContact.AccountId = updatedContact.AccountId ?? existingContact.AccountId;
            existingContact.DateUpdated = DateTime.Now;

            await context.SaveChangesAsync();
            return Results.Ok(existingContact);
        });

        contactGroup.MapDelete("/{id:int}", async (int id, AppDbContext context) =>
        {
            var contact = await context.Contacts.FindAsync(id);
            if (contact is null) return Results.NotFound();

            context.Contacts.Remove(contact);
            await context.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
