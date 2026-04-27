using System;
using CORE.Entities;
using CORE.Interface;

namespace INFRASTRUCTURE.Datas;

public class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }
        //Where Query For Filteration

        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy);
        }
        //OrderBy Query For Sorting In Ascending Order

        if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending);
        }
        //OrderByDescending Query For Sorting In Descending Order

        if(spec.IsDistinct)
        {
            query = query.Distinct();
        }
        //Distinct Query For Removing The Duplicate Records From The Result Set

        return query;
    }


    public static IQueryable<TResult> GetQuery<TSpec, TResult>(IQueryable<T> query, 
    ISpecification<T, TResult > spec)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }
        //Where Query For Filteration

        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy);
        }
        //OrderBy Query For Sorting In Ascending Order

        if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending);
        }
        //OrderByDescending Query For Sorting In Descending Order

        var select_query = query as IQueryable<TResult>;

        if(spec.Select != null)
        {
            select_query = query.Select(spec.Select);
        }
        //Select Query For Selecting The Particular Column From The Table
        
        if(spec.IsDistinct)
        {
            select_query = select_query?.Distinct();
        }
        //Distinct Query For Removing The Duplicate Records From The Result Set
        
        return select_query ?? query.Cast<TResult>();
    }

}