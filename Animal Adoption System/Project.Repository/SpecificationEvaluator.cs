using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Project.Core.Specifications.BaseAndIspec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery, ISpecification<T> Spec)
        {
            var Query = InputQuery; //_dbcontext.set<T>
            if (Spec.Criteria is not null) //p=>p.id
            {
                Query = Query.Where(Spec.Criteria); //where p=>p.id
            }

            if (Spec.OrderBy is not null)
            {
                Query = Query.OrderBy(Spec.OrderBy);
            }

            if (Spec.OrderByDesc is not null)
            {
                Query = Query.OrderByDescending(Spec.OrderByDesc);
            }
            if (Spec.IsPaginationEnabled)
            {
                Query = Query.Skip(Spec.Skip).Take(Spec.Take);
            }

            Query = Spec.Includes.Aggregate(Query, (currentQuery, IncludeExpression) => currentQuery.Include(IncludeExpression));

            return Query;
        }
    }
}
