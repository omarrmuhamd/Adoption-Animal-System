using Core.Entities;
using Project.Core.Specifications.BaseAndIspec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Repositories
{
    public interface IGenericRepository <T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> GetById( int id );


        Task<IReadOnlyList<T>> GetAllWithSpecification(ISpecification<T> spec);

        Task<T> GetByIdWithSpec (ISpecification<T> spec);

        Task<int> GetCountWithSpec(ISpecification<T> spec);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);



    }
}
