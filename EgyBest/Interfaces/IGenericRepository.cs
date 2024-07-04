using EgyBest.Domain.Models;
using EgyBest.Infrastructure.Specifications;

namespace EgyBest.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetAllSpec(ISpecefication<T> spec);
        Task<T> GetByIdWithSpec(ISpecefication<T> spec);
        Task<int> GetCountWithSpec(ISpecefication<T> spec);
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);

    }
}
