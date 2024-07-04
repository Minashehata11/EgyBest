using AutoMapper;
using EgyBest.Domain.Models;
using EgyBestFilm.Application.Dtos;

namespace EgyBestFilm.Application.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie,MovieDto>()
                .ForMember(dest=>dest.DirectorName,src=>src.MapFrom(m=>m.Director.Name))
                .ForMember(dest=>dest.PosterImage,src=>src.MapFrom<PostMovieUrlResolver>());
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<MovieWithGenre, MovieGenere>();
            CreateMap<Genere, GeneraDto>();
        }
    }
}
