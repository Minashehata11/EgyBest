using EgyBest.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyBestFilm.Application.Dtos
{
    public class CreateMovieDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public float Rate { get; set; }
        public float? MovieLenght { get; set; }
        public string Language { get; set; }
        public IFormFile? Poster { get; set; }
        public int DirectorId { get; set; }
    }
}
