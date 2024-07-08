using EgyBest.Infrastructure.Specefications.MovieSpecefication;
using EgyBestFilm.Application.Dtos;
using EgyBestFilm.Application.ErrorHandle;
using EgyBestFilm.Application.Helper;
using EgyBestFilm.Application.Services.MovieService;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace EgyBest.Presentaion.Controllers
{

    public class MovieController : BaseController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(PaginatedResultDto<MovieDto>),StatusCodes.Status200OK)]

        public async Task<ActionResult<PaginatedResultDto<MovieDto>>> GetAll([FromQuery]SpecParameter spec)
            => Ok(await _movieService.GetAllMovies(spec));
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ErrorApiResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(MovieDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginatedResultDto<MovieDto>>> GetbyId(int id)
        {
            var movie = await _movieService.GetByIdMovies(id);
            if (movie == null)
                return NotFound(new ErrorApiResponse(404, "Not Found Movie"));
            return Ok(movie);
        }
        [HttpPut]
        public async Task<ActionResult> Rate(int id,float rate)
        {
            var Result= await _movieService.AddRate(id,rate);
            if (Result == true)
                return Ok();
            else
                return BadRequest(new ErrorApiResponse(400));
        }
        [HttpGet("GetGeneras")]
        public async Task<ActionResult<IReadOnlyList<GeneraDto>>> GetGeneras()
           => Ok(await _movieService.GetAllGeners());
        [HttpGet("GetGeneras{id}")]

        public async Task<ActionResult<GeneraDto>> GetGeneaById(int id)
        {
            var Geneara= await _movieService.GetGenreById(id);
            if (Geneara == null)
                return NotFound(new ErrorApiResponse(404));
            return Ok(Geneara);
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return Ok();
        }

    }
}
