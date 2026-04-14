using System;
using System.Linq.Expressions;

namespace CORE.Interface;

public interface ISpecification<T>
{
 Expression<Func<T, bool>>? Criteria { get; }
 //Proeprty Name Is Criteria and its type is Expression<Func<T, bool>>
}
