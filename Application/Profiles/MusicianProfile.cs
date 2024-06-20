using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    internal class MusicianProfile : Profile
    {
        public MusicianProfile()
        {
            CreateMap<MusicianDto , Musician>();
            CreateMap<Musician, MusicianDto>();
        }
    }
}
