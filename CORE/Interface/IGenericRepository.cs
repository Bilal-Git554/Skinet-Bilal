using System;
using CORE.Entities;

namespace CORE.Interface;

public interface IGenericRepository<T> where T : BaseEntity
{
  Task<T?> GetByIdAsync(int id);
  Task<IReadOnlyList<T>> ListAllAsync();
  void AddAsync(T entity);
  void UpdateAsync(T entity);
  void DeleteAsync(T entity);
  Task<bool> SaveAllAsync();
  bool Exists(int id);

}
