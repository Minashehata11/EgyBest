using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyBestFilm.Application.Dtos
{
    public class MovieWithGenre
    {
        public CreateMovieDto MovieDto { get; set; }
        public int GenreId { get; set; }
    }
}
