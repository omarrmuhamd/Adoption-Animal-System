using Project.Core.Entities;
using Project.Core.Specifications.BaseAndIspec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Specifications.AnimalSpec
{
    public class AnimalSpec : Specification<Animal>
    {
        public AnimalSpec(AnimalSpecParams Params) : 
            base(p => (string.IsNullOrEmpty(Params.AnimalNameSearch) || (p.Name != null  && p.Name.ToLower().Contains(Params.AnimalNameSearch)))
            && (!Params.BreedId.HasValue|| p.AnimalBreedId ==Params.BreedId)
            && (!Params.TypeId.HasValue || p.AnimalTypeId == Params.TypeId))
        {
            AddIncludes();


            if (!string.IsNullOrEmpty(Params.Sort))
            {
                switch (Params.Sort)
                {
                    case "AgeAsc":
                        GetOrderBy(a => a.Age);
                        break;

                    case "AgeDesc":
                        GetOrderByDesc(a => a.Age);
                        break;
                    default:
                        GetOrderBy(a => a.Name);
                        break;
                }
            }
            ApplyPagination(Params.pageSize*(Params.PageIndex-1), Params.pageSize);
        }


        public AnimalSpec(int id) : base(p => p.Id == id)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
      
            Includes.Add(t => t.AnimalType);
            Includes.Add(b => b.AnimalBreed);
            Includes.Add(b => b.Shelter);

        }
    }
}