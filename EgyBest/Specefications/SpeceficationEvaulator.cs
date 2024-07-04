using EgyBest.Domain.Models;
using EgyBest.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace EgyBest.Infrastructure.Specefications
{
    public class SpeceficationEvaulator<T>where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery, ISpecefication<T> specs)
        {
            var query = InputQuery;
            if (specs.Expressions != null)
                query = query.Where(specs.Expressions);
            if(specs.OrderBy != null)
                query = query.OrderBy(specs.OrderBy);
            if(specs.OrderByDescending != null)
                query = query.OrderByDescending(specs.OrderByDescending);
            if(specs.IsPaginated==true)
               query=query.Skip(specs.Skip).Take(specs.Take);
            query = specs.Includes.Aggregate(query, (current, includeExprision) => current.Include(includeExprision));

            return query;
        }
    }
}
