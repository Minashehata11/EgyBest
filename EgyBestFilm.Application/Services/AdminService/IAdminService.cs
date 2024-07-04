using EgyBestFilm.Application.Dtos;

namespace EgyBestFilm.Application.Services.AdminService
{
    public interface IAdminService
    {
        Task AddGenre(string genreName);
        Task<bool> DeleteGenre(int id);
       
    }
}
