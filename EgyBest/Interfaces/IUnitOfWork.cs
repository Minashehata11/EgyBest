using EgyBest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyBest.Infrastructure.Interfaces
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity:BaseEntity;
        Task<int> CompleteAsync();
        public void Add<T>(T entity) where T : class;
       
    }
}
