using EgyBestFilm.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgyBestFilm.Application.Services.SuperAdminService
{
    public interface ISuperAdminService
    {
        public Task<bool> AddAdmin(RegisterDto dto);
        public Task<bool> DeleteAdmin(string id);
    }
}
