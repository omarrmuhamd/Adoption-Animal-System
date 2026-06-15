using Project.Core.Entities;
using Project.Core.Specifications.BaseAndIspec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Specifications.AdoptSpec
{
    public class AdoptionByUserSpec :Specification<AdoptionRequest>
    {

        //for user myrequest
        public AdoptionByUserSpec(string userId): base(x => x.UserId == userId)
        {
            Includes.Add(x => x.Animal);
        }

        //for admin all requests
        public AdoptionByUserSpec()
        {
            Includes.Add(x => x.Animal);
        }
    }
}
