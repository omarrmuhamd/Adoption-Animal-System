using Project.Core.Entities;
using Project.Core.Specifications.BaseAndIspec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Specifications.AdoptSpec
{
    public class AdoptionExistSpec : Specification<AdoptionRequest>  // to stop dup req
    {
        public AdoptionExistSpec(string userId, int animalId)
            : base(x => x.UserId == userId && x.AnimalId == animalId)
        {
        }


     

    }
}
