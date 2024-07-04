using EgyBest.Domain.Models;
using EgyBest.Infrastructure.Specefications.MovieSpecefication;
using EgyBestFilm.Application.Dtos;
using EgyBestFilm.Application.Helper;

namespace EgyBestFilm.Application.Services.MovieService
{
    public interface IMovieService
    {
        Task<PaginatedResultDto<MovieDto>> GetAllMovies(SpecParameter spec);
        Task<MovieDto> GetByIdMovies(int id);
        public Task<bool> AddRate(int id,float rate);
        public Task<IReadOnlyList<GeneraDto>> GetAllGeners();
        public Task<GeneraDto> GetGenreById(int id);


    }
}
