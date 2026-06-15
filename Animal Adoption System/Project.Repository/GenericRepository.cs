using Microsoft.EntityFrameworkCore;
using Project.Core.Repositories;
using Project.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Project.Core.Specifications.BaseAndIspec;
using Project.Repository.Data;

namespace Project.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly ProjectContext _dbcontext;
        public GenericRepository(ProjectContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        private IQueryable<T> ApplySpec(ISpecification<T> Spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbcontext.Set<T>(), Spec);
        }
        async Task<IReadOnlyList<T>> IGenericRepository<T>.GetAll()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

       async  Task<IReadOnlyList<T>> IGenericRepository<T>.GetAllWithSpecification(ISpecification<T> spec)
        {
            return await ApplySpec(spec).ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);

        }

        public async Task<T> GetByIdWithSpec(ISpecification<T> spec)
        {
            return await ApplySpec(spec).FirstOrDefaultAsync();
        }
        public async Task<int> GetCountWithSpec(ISpecification<T> spec)
        {
            return await ApplySpec(spec).CountAsync();
        }


        public async Task AddAsync(T entity)
        {
             _dbcontext.Set<T>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbcontext.Set<T>().Update(entity);
            await _dbcontext.SaveChangesAsync();


        }

        public async Task DeleteAsync(T entity)
        {
            _dbcontext.Set<T>().Remove(entity);
            await _dbcontext.SaveChangesAsync();

        }


    }
}
