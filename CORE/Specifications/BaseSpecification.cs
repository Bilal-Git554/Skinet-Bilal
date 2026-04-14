using System;
using System.Linq.Expressions;
using CORE.Interface;
namespace CORE.Specifications;

public class BaseSpecification<T> : ISpecification<T>
{
    private readonly Expression<Func<T, bool>>? criteria;
    protected  BaseSpecification(Expression<Func<T, bool>>? _criteria) 
    {
        criteria = _criteria;
    }
    protected BaseSpecification()
    {
        criteria = null;
    }
    public Expression<Func<T, bool>>? Criteria
    {
        get{return criteria;}
    }
    //Set The Return Value To The Criteria Property
}

