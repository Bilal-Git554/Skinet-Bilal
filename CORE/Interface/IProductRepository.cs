using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CORE.Entities;
namespace CORE.Interface;

public interface IProductRepository
{
    Task<IReadOnlyList<Products>> GetProductsAsync(string? brand , string? type, string? sort);
    Task<Products?> GetProductByIdAsync(int id);
    Task<IReadOnlyList<string>> GetBrandsAsync();
    Task<IReadOnlyList<string>> GetTypesAsync();
    void AddProduct(Products p_Add);
    void UpdateProduct(Products p_Update);
    void DeleteProduct(Products p_Delete);
    bool ProductExists(int id);
    Task<bool> SaveAllChangesAsync();

}
