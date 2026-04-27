using System;
using CORE.Entities;

namespace CORE.Specifications;

public class BrandListSpecification : BaseSpecification<Products, string>
{
  public BrandListSpecification() : base()
  {
    AddSelect(x => x.Brand);
    ApplyDistinct();
  }

}
