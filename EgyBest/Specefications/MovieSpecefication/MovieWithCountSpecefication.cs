using EgyBest.Domain.Models;
using EgyBest.Infrastructure.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyBest.Infrastructure.Specefications.MovieSpecefication
{
    public class MovieWithCountSpecefication : BaseSpecefication<Movie>
    {
        public MovieWithCountSpecefication(SpecParameter param) :
            base
            (
              M =>
                (string.IsNullOrEmpty(param.Search) || M.Title.ToLower().Trim().Contains(param.Search))
               &&
                (!param.DirectorId.HasValue || param.DirectorId == M.DirectorId)


            )
        {

        }
    }
}
