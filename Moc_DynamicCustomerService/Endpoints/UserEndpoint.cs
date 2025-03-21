using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace Moc_DynamicCustomerService.Endpoints;
public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        var userGroup = app.MapGroup("/users");

        userGroup.MapGet("/", async (AppDbContext context) =>
        {
            var users = await context.Users.ToListAsync();
            return users;
        });

        userGroup.MapGet("/{id:int}", async (int id, AppDbContext context) =>
        {
            var user = await context.Users.FindAsync(id);
            return user is null ? Results.NotFound() : Results.Ok(user);
        });

        userGroup.MapPost("/", async (Users user, AppDbContext context) =>
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return Results.Created($"/users/{user.User_id}", user);
        });

        userGroup.MapPatch("/{id:int}", async (int id, Update_User updatedUser, AppDbContext context) =>
        {
            var existingUser = await context.Users.FindAsync(id);
            if (existingUser is null) return Results.NotFound();

            existingUser.Name = updatedUser.Name ?? existingUser.Name;
            existingUser.LastName = updatedUser.LastName ?? existingUser.LastName;
            existingUser.Login = updatedUser.Login ?? existingUser.Login;
            existingUser.Role = updatedUser.Role ?? existingUser.Role;

            await context.SaveChangesAsync();
            return Results.Ok(existingUser);
        });

        userGroup.MapDelete("/{id:int}", async (int id, AppDbContext context) =>
        {
            var user = await context.Users.FindAsync(id);
            if (user is null) return Results.NotFound();

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
