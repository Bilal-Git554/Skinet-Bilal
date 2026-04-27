using System;
using System.Linq.Expressions;

namespace CORE.Interface;

public interface ISpecification<T>
{
 Expression<Func<T, bool>>? Criteria { get; }
 //Property Name Is Criteria And Its Type Is Expression<Func<T, bool>>
 Expression<Func<T, object>>? OrderBy { get; }
 //Property Name Is OrderBy And Its Type Is Expression<Func<T, object>>
 Expression<Func<T, object>>? OrderByDescending { get; }
 //Property Name Is OrderByDescending And Its Type Is Expression<Func<T, object>>
 bool IsDistinct { get; }
 //Property Name Is IsDistinct And Its Type Is bool
}
//For Filtering And Sorting 

public interface ISpecification<T, TResult> : ISpecification<T>
{
    Expression<Func<T, TResult>>? Select {get;}
}
//For Projection(DTO)