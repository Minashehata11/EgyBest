using EgyBest.Domain.Models.Identity;

namespace EgyBest.Domain.Models
{
    public class Movie:BaseEntity
    {
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public float Rate { get; set; }
        public List<double>? CalculateRate { get; set; } = new List<double>() { };
        public float? MovieLenght { get; set; }
        public string Language { get; set; } = "English";
        public string? PosterImage { get; set; }
        public Director Director  { get; set; }
        public int DirectorId { get; set; }
    }
}
