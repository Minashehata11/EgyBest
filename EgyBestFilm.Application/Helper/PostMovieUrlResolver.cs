using AutoMapper;
using EgyBest.Domain.Models;
using EgyBestFilm.Application.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyBestFilm.Application.Helper
{
    public class PostMovieUrlResolver : IValueResolver<Movie, MovieDto, string>
    {
        private readonly IConfiguration _configuration;

        public PostMovieUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Movie source, MovieDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PosterImage))
              return $"{_configuration["ApiBaseUrlResolver"]}Files/Poster/{source.PosterImage}";
            else
              return string.Empty;
        }
    }
}
