using System;
using System.Linq.Expressions;

namespace CORE.Interface;

public interface ISpecification<T>
{
 Expression<Func<T, bool>>? Criteria { get; }
 //Proeprty Name Is Criteria and its type is Expression<Func<T, bool>>
 Expression<Func<T, object>>? OrderBy { get; }
//Proeprty Name Is OrderBy and its type is Expression<Func<T, object>>
 Expression<Func<T, object>>? OrderByDescending { get; }
 //Proeprty Name Is OrderByDescending and its type is Expression<Func<T, object>>
}
