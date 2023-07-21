using AutoMapper;
using EWebApi.DTO;
using EWebApi.Models;

namespace EWebApi
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<CompanyDTO, Company>();
            CreateMap<ContactDTO, Contact>();
        }
    }
}
