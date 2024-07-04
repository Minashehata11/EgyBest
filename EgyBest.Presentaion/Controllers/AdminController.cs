using AutoMapper;
using EgyBest.Domain.Models;
using EgyBest.Infrastructure.Interfaces;
using EgyBest.Presentaion.Setting;
using EgyBestFilm.Application.Dtos;
using EgyBestFilm.Application.ErrorHandle;
using EgyBestFilm.Application.Services.AdminService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyBest.Presentaion.Controllers
{

    [Authorize(Roles = "Admin,SuperAdmin")]
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public AdminController(IAdminService adminService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _adminService = adminService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> AddGenre(string Name)
        {
            await _adminService.AddGenre(Name);
            return Ok();
        }
        [ProducesErrorResponseType(typeof(ErrorApiResponse))]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenre(int id)
            => Ok(await _adminService.DeleteGenre(id) ? "Genre deleted successfully" : Ok(new ErrorApiResponse(400, "Not Found Genera")));
        [HttpPost("AddMovie")]
        public async Task<ActionResult> AddMoview([FromForm] MovieWithGenre dto)
        {
            var MovieMapped = _mapper.Map<Movie>(dto.MovieDto);
            if(!(dto.MovieDto.Poster ==null))
                 MovieMapped.PosterImage = DocumentSetting.UplouadFile(dto.MovieDto.Poster, "Poster");
            MovieGenere movieGenere = new MovieGenere()
            {
                Movie = MovieMapped,
                GenreId = dto.GenreId,
            };
            _unitOfWork.Add(movieGenere);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }

        [HttpDelete("DeleteMovie{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Movie=await _unitOfWork.Repository<Movie>().GetById(id);
            DocumentSetting.DeleteFile(Movie.PosterImage, "Poster");
            if (Movie == null)
                return NotFound(new ErrorApiResponse(404));
            _unitOfWork.Repository<Movie>().DeleteEntity(Movie);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }
 
    }
}