using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class AlbunProfile : Profile
    {
        public AlbunProfile()
        {
            CreateMap<AlbunDto, Albun>();
            CreateMap<Albun, AlbunDto>();
        }
    }
}
