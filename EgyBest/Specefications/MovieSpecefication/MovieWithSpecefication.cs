using EgyBest.Domain.Models;
using EgyBest.Infrastructure.Specifications;

namespace EgyBest.Infrastructure.Specefications.MovieSpecefication
{
    public class MovieWithSpecefication : BaseSpecefication<Movie>
    {
        public MovieWithSpecefication(SpecParameter param) : 
            base
            (
              M=>
                (string.IsNullOrEmpty(param.Search)|| M.Title.ToLower().Trim().Contains(param.Search))
               &&
                (! param.DirectorId.HasValue ||  param.DirectorId==M.DirectorId)
             
              
            )
        {

            Includes.Add(m => m.Director);

            if (!string.IsNullOrEmpty(param.Sort))
            {
                switch (param.Sort)
                {
                    case "Rate":
                        AddOrder(m=>m.Rate);
                        break;
                    case "RateDesc":
                        AddOrderDesc(m=>m.Rate);
                        break;
                    default:
                        AddOrder(m=>m.Name);
                        break;
     
                }
            }
            AddPaginated(param.PageSize * (param.PageIndex - 1), param.PageSize);

        }

        public MovieWithSpecefication(int id):base(m=>m.Id==id)
          =>  Includes.Add(m => m.Director);
        
    }
}
