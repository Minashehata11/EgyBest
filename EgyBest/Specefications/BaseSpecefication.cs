using EgyBest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EgyBest.Infrastructure.Specifications
{
    public class BaseSpecefication<T> : ISpecefication<T>where T : BaseEntity
    {
        public Expression<Func<T, bool>> Expressions { get ; set ; }
        public List<Expression<Func<T, object>>> Includes { get ; set; } =new List<Expression<Func<T, object>>> ();
        public Expression<Func<T, object>> OrderBy { get ; set ; }
        public Expression<Func<T, object>> OrderByDescending { get ; set ; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPaginated { get; set; }

        public BaseSpecefication()
        { }
        public BaseSpecefication(Expression<Func<T, bool>> expressions)
           =>  Expressions = expressions;
        public void AddOrder(Expression<Func<T, object>> orderby)
           => OrderBy = orderby;
        public void AddOrderDesc(Expression<Func<T, object>> orderbyDec)
          => OrderByDescending = orderbyDec;
        public void AddPaginated(int skip,int take)
        {
            IsPaginated = true;
            Take = take;
            Skip=skip;
        }

    }
}
