using AutoMapper;
using EgyBest.Domain.Models;
using EgyBestFilm.Application.Dtos;
using System.Xml.XPath;


namespace EgyBestFilm.Application.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddGenre(string genreName)
        {
            Genere genere = new Genere() { Name = genreName };  
             _unitOfWork.Repository<Genere>().AddEntity(genere);
             await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteGenre(int id)
        {
            var genera = await _unitOfWork.Repository<Genere>().GetById(id);
            if (genera==null)
                 return false; 
            _unitOfWork.Repository<Genere>().DeleteEntity(genera);
            await _unitOfWork.CompleteAsync();
            return true;
        }

       

    }
}
