using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    internal class AdminProfile : Profile
    {
        public AdminProfile()
        {
        CreateMap<AdminDto, Admin>();
        CreateMap<Admin, AdminDto>();
        }
    }
}
