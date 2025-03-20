using Example.Data;
using Example.Models;
using Microsoft.EntityFrameworkCore;


namespace Example.Services;
public class ProductService(AppDbContext context) : IProductService
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Products>> GetAllAsync()
    {
        return await _context.Products
            .Include(c => c.Licenses)
            .ToListAsync();
    }

    public async Task<Products?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(c => c.Licenses)
            .FirstOrDefaultAsync(c => c.Product_id == id);
    }

    public async Task<Products> CreateAsync(Products newProduct)
    {
        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();
        return newProduct;
    }

    public async Task<bool> UpdateAsync(int id, Update_Product updatedProduct)
    {
        var existingProduct = await _context.Products.FindAsync(id);
        if (existingProduct == null) return false;

        // Aktualizacja tylko przekazanych pól
        existingProduct.Name = updatedProduct.Name ?? existingProduct.Name;
        existingProduct.Description = updatedProduct.Description ?? existingProduct.Description;
        existingProduct.Price = updatedProduct.Price ?? existingProduct.Price;
        existingProduct.Category = updatedProduct.Category ?? existingProduct.Category;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingProduct = await _context.Products.FindAsync(id);
        if (existingProduct == null) return false;

        _context.Products.Remove(existingProduct);
        await _context.SaveChangesAsync();
        return true;
    }
}
