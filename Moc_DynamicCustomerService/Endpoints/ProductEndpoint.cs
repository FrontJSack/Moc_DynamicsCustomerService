using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;

namespace Moc_DynamicCustomerService.Endpoints;
public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        var productGroup = app.MapGroup("/products");

        productGroup.MapGet("/", async (AppDbContext context) =>
        {
            var products = await context.Products.ToListAsync();
            return products;
        });

        productGroup.MapGet("/{id:int}", async (int id, AppDbContext context) =>
        {
            var product = await context.Products.FindAsync(id);
            return product is null ? Results.NotFound() : Results.Ok(product);
        });

        productGroup.MapPost("/", async (Products product, AppDbContext context) =>
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
            return Results.Created($"/products/{product.Product_id}", product);
        });

        productGroup.MapPatch("/{id:int}", async (int id, Update_Product updatedProduct, AppDbContext context) =>
        {
            var existingProduct = await context.Products.FindAsync(id);
            if (existingProduct is null) return Results.NotFound();

            existingProduct.Name = updatedProduct.Name ?? existingProduct.Name;
            existingProduct.Category = updatedProduct.Category ?? existingProduct.Category;
            existingProduct.Description = updatedProduct.Description ?? existingProduct.Description;
            existingProduct.Price = updatedProduct.Price ?? existingProduct.Price;

            await context.SaveChangesAsync();
            return Results.Ok(existingProduct);
        });

        productGroup.MapDelete("/{id:int}", async (int id, AppDbContext context) =>
        {
            var product = await context.Products.FindAsync(id);
            if (product is null) return Results.NotFound();

            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
