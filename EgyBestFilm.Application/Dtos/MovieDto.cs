using EgyBest.Domain.Models;

namespace EgyBestFilm.Application.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public float Rate { get; set; }
        public float? MovieLenght { get; set; }
        public string Language { get; set; } = "English";
        public string? PosterImage { get; set; }
        public string DirectorName { get; set; }
        public int DirectorId { get; set; }
    }
}
