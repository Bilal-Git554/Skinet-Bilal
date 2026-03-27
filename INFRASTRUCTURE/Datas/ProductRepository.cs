using System;
using Microsoft.EntityFrameworkCore;
using CORE.Entities;
using CORE.Interface;
namespace INFRASTRUCTURE.Datas;

public class ProductRepository : IProductRepository
{
    private  readonly StoreContext _context;

    public ProductRepository(StoreContext context)
    {
        _context = context;
    }

    public void AddProduct(Products p_Add)
    {
        _context.Product.Add(p_Add);
    }

    public void UpdateProduct(Products p_Update)
    {
      _context.Entry(p_Update).State = EntityState.Modified;
    }

    public void DeleteProduct(Products p_Delete)
    {
        _context.Product.Remove(p_Delete);
    }

    public async Task<Products?> GetProductByIdAsync(int id)
    {
        return await _context.Product.FindAsync(id);
    }

    public async Task<IReadOnlyList<Products>> GetProductsAsync(string? brand , string? type)
    {
        var query = _context.Product.AsQueryable();
        
        if(!string.IsNullOrEmpty(brand))
        {
            query = query.Where(p => p.Brand == brand);
        }

        if(!string.IsNullOrEmpty(type))
        {
            query = query.Where(p => p.Type == type);
        }

        return await query.ToListAsync();
    }
    
    public async Task<IReadOnlyList<string>> GetBrandsAsync()
    {
        return await _context.Product.Select(p => p.Brand).Distinct().ToListAsync();
    }

    public async Task<IReadOnlyList<string>> GetTypesAsync()
    {
        return await _context.Product.Select(p => p.Type).Distinct().ToListAsync();
    }
    public async Task<bool> SaveAllChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public bool ProductExists(int id)
    {
        return _context.Product.Any(p => p.Id == id);
    }

}
