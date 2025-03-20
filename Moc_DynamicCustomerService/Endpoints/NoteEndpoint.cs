using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace Moc_DynamicCustomerService.Endpoints;
public static class NoteEndpoints
{
    public static void MapNoteEndpoints(this WebApplication app)
    {
        var noteGroup = app.MapGroup("/notes");

        noteGroup.MapGet("/", async (AppDbContext context) =>
        {
            var notes = await context.Notes.ToListAsync();
            return notes;
        });

        noteGroup.MapGet("/{id:int}", async (int id, AppDbContext context) =>
        {
            var note = await context.Notes.FindAsync(id);
            return note is null ? Results.NotFound() : Results.Ok(note);
        });

        noteGroup.MapPost("/", async (Notes note, AppDbContext context) =>
        {
            context.Notes.Add(note);
            await context.SaveChangesAsync();
            return Results.Created($"/notes/{note.Note_id}", note);
        });

        noteGroup.MapPatch("/{id:int}", async (int id, UpdateNote updatedNote, AppDbContext context) =>
        {
            var existingNote = await context.Notes.FindAsync(id);
            if (existingNote is null) return Results.NotFound();

            existingNote.Content = updatedNote.Content ?? existingNote.Content;

            await context.SaveChangesAsync();
            return Results.Ok(existingNote);
        });

        noteGroup.MapDelete("/{id:int}", async (int id, AppDbContext context) =>
        {
            var note = await context.Notes.FindAsync(id);
            if (note is null) return Results.NotFound();

            context.Notes.Remove(note);
            await context.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
