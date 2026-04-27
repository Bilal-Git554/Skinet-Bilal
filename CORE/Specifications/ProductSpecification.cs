using System;
using CORE.Entities;

namespace CORE.Specifications;
    
public class ProductSpecification : BaseSpecification<Products>
{
public ProductSpecification(string? brand , string? type , string? sort) : base(x => 
    (string.IsNullOrEmpty(brand) || x.Brand == brand) && 
    (string.IsNullOrEmpty(type) || x.Type == type))
    //Returning To The Child Class Because Of The Base

{
    
        switch (sort)
        {
            case "priceAsc":
                AddOrderBy(p => p.Price);
                break;

            case "priceDesc":
                AddOrderByDescending(p => p.Price);
                break;
                
            default:
                AddOrderBy(p => p.Name);
                break;
        }
}

}
