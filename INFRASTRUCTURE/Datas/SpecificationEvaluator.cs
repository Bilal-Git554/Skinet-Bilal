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

        return query;
    }
}
