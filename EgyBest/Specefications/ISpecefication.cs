using EgyBest.Domain.Models;
using System.Linq.Expressions;

namespace EgyBest.Infrastructure.Specifications
{
    public interface ISpecefication<T> where T : BaseEntity
    {
        public Expression<Func<T,bool>> Expressions { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDescending { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginated { get; set; }
    }
}
