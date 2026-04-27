using System;
using CORE.Entities;

namespace CORE.Specifications;

public class TypeListSpecification : BaseSpecification<Products, string>
{
  public TypeListSpecification() : base()
  {
    AddSelect(x => x.Type);
    ApplyDistinct();
  }
  
}
