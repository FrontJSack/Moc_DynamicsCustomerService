using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace Moc_DynamicCustomerService.Endpoints;
public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this WebApplication app)
    {
        var accountGroup = app.MapGroup("/accounts");

        accountGroup.MapGet("/", async (AppDbContext context) =>
        {
            var accounts = await context.Accounts
                .Include(a => a.Sla_contracts)
                .Include(a => a.Licenses)
                .Include(a => a.Contacts)
                .Include(a => a.Cases)
                .ToListAsync();
            return accounts;
        });

        accountGroup.MapGet("/{id}", async (int id, AppDbContext context) =>
        {
            var account = await context.Accounts
                .Include(a => a.Sla_contracts)
                .Include(a => a.Licenses)
                .Include(a => a.Contacts)
                .Include(a => a.Cases)
                .FirstOrDefaultAsync(a => a.Account_id == id);
            if (account is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(account);
        });

        accountGroup.MapPost("/", async (Accounts account, AppDbContext context) =>
        {
            context.Accounts.Add(account);
            await context.SaveChangesAsync();
            return Results.Created($"/accounts/{account.Account_id}", account);
        });

        accountGroup.MapPatch("/{id}", async (int id, UpdateAccount updatedAccount, AppDbContext context) =>
        {
            var existingAccount = await context.Accounts.FindAsync(id);
            if (existingAccount is null)
            {
                return Results.NotFound();
            }

            existingAccount.Industry = updatedAccount.Industry ?? existingAccount.Industry;
            existingAccount.Nip = updatedAccount.Nip ?? existingAccount.Nip;
            existingAccount.Address = updatedAccount.Address ?? existingAccount.Address;
            existingAccount.City = updatedAccount.City ?? existingAccount.City;
            existingAccount.Country = updatedAccount.Country ?? existingAccount.Country;
            existingAccount.MainEmail = updatedAccount.MainEmail ?? existingAccount.MainEmail;
            existingAccount.MainPhone = updatedAccount.MainPhone ?? existingAccount.MainPhone;

            await context.SaveChangesAsync();
            return Results.Ok(existingAccount);
        });

        accountGroup.MapDelete("/{id}", async (int id, AppDbContext context) =>
        {
            var account = await context.Accounts.FindAsync(id);
            if (account is null)
            {
                return Results.NotFound();
            }

            context.Accounts.Remove(account);
            await context.SaveChangesAsync();
            return Results.NoContent();
        });
    }


}