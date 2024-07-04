using EgyBest.Domain.Context;
using EgyBest.Domain.Models;
using EgyBest.Infrastructure.Interfaces;
using EgyBest.Infrastructure.Specefications;
using EgyBest.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace EgyBest.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MovieDbContext _movieDbContext;

        public GenericRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public void AddEntity(T entity)
        =>  _movieDbContext.Set<T>().Add(entity);

        public void DeleteEntity(T entity)
        => _movieDbContext.Set<T>().Remove(entity);

        public async Task<IReadOnlyList<T>> GetAllAsync()
        => await _movieDbContext.Set<T>().ToListAsync();

        public async Task<T> GetById(int id)
         => await _movieDbContext.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> GetAllSpec(ISpecefication<T> spec)
         => await ApplySpecification(spec).ToListAsync();

        public async Task<T> GetByIdWithSpec(ISpecefication<T> spec)
         => await  ApplySpecification(spec).FirstOrDefaultAsync();

        public void UpdateEntity(T entity)
        => _movieDbContext.Update(entity);
        public async Task<int> GetCountWithSpec(ISpecefication<T> spec)
          =>  await ApplySpecification(spec).CountAsync();  
        private IQueryable<T> ApplySpecification(ISpecefication<T> spec)
           => SpeceficationEvaulator<T>.GetQuery(_movieDbContext.Set<T>(), spec);

    }
}
