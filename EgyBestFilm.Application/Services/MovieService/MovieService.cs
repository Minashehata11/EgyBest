using AutoMapper;
using EgyBest.Domain.Models;
using EgyBest.Infrastructure.Specefications.MovieSpecefication;
using EgyBestFilm.Application.Dtos;

namespace EgyBestFilm.Application.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
           
        }

        public async Task<bool> AddRate(int id,float rate)
        {
            var movie= await _unitOfWork.Repository<Movie>().GetById(id);
            if (movie == null)
                return false;
            movie.CalculateRate= new List<double> { rate };
            movie.Rate=(float)movie.CalculateRate.Sum()/movie.CalculateRate.Count();
            _unitOfWork.Repository<Movie>().UpdateEntity(movie);
          await  _unitOfWork.CompleteAsync();
            return true;
               }

        public async Task<IReadOnlyList<GeneraDto> > GetAllGeners()
        {
            var Geners=await _unitOfWork.Repository<Genere>().GetAllAsync();
             var MappedData=_mapper.Map<IReadOnlyList<GeneraDto>>(Geners);
            return MappedData;
        }

        public async Task<PaginatedResultDto<MovieDto>> GetAllMovies(SpecParameter spec)
        {
            var specs=new MovieWithSpecefication(spec);
            var Movies=await _unitOfWork.Repository<Movie>().GetAllSpec(specs);
            var mappedData = _mapper.Map<IReadOnlyList<MovieDto>>(Movies);
            var specCount = new MovieWithCountSpecefication(spec);
            var count= await _unitOfWork.Repository<Movie>().GetCountWithSpec(specs);
            return new PaginatedResultDto<MovieDto>(spec.PageIndex, spec.PageSize, count,mappedData);

        }

        public async Task<MovieDto> GetByIdMovies(int id)
        {
            var spec = new MovieWithSpecefication(id);
            var movie= await _unitOfWork.Repository<Movie>().GetByIdWithSpec(spec);

            if (movie == null)
                return null;
            var mappedData=_mapper.Map<MovieDto>(movie);
            return mappedData;
        }

        public async Task<GeneraDto> GetGenreById(int id)
        {
            var Geners = await _unitOfWork.Repository<Genere>().GetById(id);
            if (Geners == null)
                return null;
            var MappedData = _mapper.Map<GeneraDto>(Geners);
            return MappedData;
        }
    }
}
