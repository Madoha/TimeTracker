using AutoMapper;
using TimeTracker.DTOs;
using TimeTracker.Models.Entities;

namespace TimeTracker.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<NewsDto, News>().ReverseMap();
        }
    }
}
