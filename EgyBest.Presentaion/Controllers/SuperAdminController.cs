using EgyBestFilm.Application.Dtos;
using EgyBestFilm.Application.ErrorHandle;
using EgyBestFilm.Application.Services.SuperAdminService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyBest.Presentaion.Controllers
{
    [Authorize(Roles ="SuperAdmin")]
    public class SuperAdminController : BaseController
    {
        private readonly ISuperAdminService _superAdminService;

        public SuperAdminController(ISuperAdminService superAdminService)
        {
            _superAdminService = superAdminService;
        }

        [HttpPost]
        public async Task<ActionResult> AddAdmin(RegisterDto dto)
         => Ok(await _superAdminService.AddAdmin(dto) ? "SUCESS" : BadRequest(new ErrorApiResponse(400)));
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdmin(string id)
         => Ok(await _superAdminService.DeleteAdmin(id) ? "SUCESS" : BadRequest(new ErrorApiResponse(400)));
        
    }
}
