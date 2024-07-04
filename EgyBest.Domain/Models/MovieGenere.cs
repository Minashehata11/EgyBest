using System.Text.RegularExpressions;

namespace EgyBest.Domain.Models
{
    public class MovieGenere
    {
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Genere Genere { get; set; }
        public int GenreId { get; set; }
    }
}
