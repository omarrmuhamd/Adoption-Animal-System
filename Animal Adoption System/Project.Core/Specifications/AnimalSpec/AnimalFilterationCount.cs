using Project.Core.Entities;
using Project.Core.Specifications.BaseAndIspec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Specifications.AnimalSpec
{
    public class AnimalFilterationCount :Specification<Animal>
    {
        public AnimalFilterationCount(AnimalSpecParams Params): base(p=>
        (!Params.BreedId.HasValue || p.AnimalBreedId == Params.BreedId)
     && (!Params.TypeId.HasValue || p.AnimalTypeId == Params.TypeId))

        {
            
        }
    }
}
