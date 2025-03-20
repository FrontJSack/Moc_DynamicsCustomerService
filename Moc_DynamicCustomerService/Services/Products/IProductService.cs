using Example.Models;

public interface IProductService
{
    Task<IEnumerable<Products>> GetAllAsync();
    Task<Products?> GetByIdAsync(int id);
    Task<Products> CreateAsync(Products newProduct);
    Task<bool> UpdateAsync(int id, Update_Product updatedProduct);
    Task<bool> DeleteAsync(int id);
}
