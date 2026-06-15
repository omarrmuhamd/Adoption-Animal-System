using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Specifications.BaseAndIspec
{
    public interface ISpecification<T> where T : BaseEntity
    {
        //where
        public Expression<Func<T,bool>> Criteria { get; set; }

        //includes
        public List<Expression<Func<T,object>>> Includes { get; set; }

        //sorting
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }

        //pagination
         public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; }







    }
}
