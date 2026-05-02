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
    
    public Expression<Func<T, object>>? OrderBy{get; private set;}
    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }
    //Price Low To High Sorting

    public Expression<Func<T, object>>? OrderByDescending{get; private set;}
    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }
    //Price High To Low Sorting

    public bool IsDistinct { get; private set; }
    protected void ApplyDistinct()
    {
        IsDistinct = true;
    }
    //Act Like On Off Switch For Distinct Query
}

public class BaseSpecification<T, TResult> : BaseSpecification<T>, ISpecification<T, TResult>
{
    protected BaseSpecification() : base(){}
    protected BaseSpecification(Expression<Func<T, bool>>? criteria) : base(criteria){}

    public Expression<Func<T, TResult>>? Select { get; private set; }
    protected void AddSelect(Expression<Func<T, TResult>> selectExpression)
    {
        Select = selectExpression;
    }
}