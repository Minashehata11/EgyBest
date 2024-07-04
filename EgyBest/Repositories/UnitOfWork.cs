using EgyBest.Domain.Context;
using EgyBest.Domain.Models;
using EgyBest.Infrastructure.Interfaces;
using System.Collections;

namespace EgyBest.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext _movieDbContext;
        private Hashtable _respositories;
        public UnitOfWork(MovieDbContext movieDbContext)
        {
            _respositories = new Hashtable();
            _movieDbContext = movieDbContext;
        }
        
        public async Task<int> CompleteAsync()
        => await _movieDbContext.SaveChangesAsync();

        public void Add<T>(T entity) where T : class 
        {
            _movieDbContext.Add(entity);
        }
        public async ValueTask DisposeAsync()
        => await _movieDbContext.DisposeAsync();

        public IGenericRepository<Tentity> Repository<Tentity>() where Tentity : BaseEntity
        {
            
            var type = typeof(Tentity).Name; //product //address
            if (!_respositories.ContainsKey(type))
            {
                var Repository = new GenericRepository<Tentity>(_movieDbContext);
                _respositories.Add(type, Repository);
            }
            return (IGenericRepository<Tentity>)_respositories[type];
        }


    }
}
