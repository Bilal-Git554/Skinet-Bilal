using System;
using CORE.Entities;
using CORE.Interface;
namespace INFRASTRUCTURE.Datas;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly StoreContext _context;
    public GenericRepository(StoreContext context)
    {
        _context = context;
    }
    //DB Connection
    public void AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public bool Exists(int id)
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> ListAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAllAsync()
    {
        throw new NotImplementedException();
    }

    public void UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
