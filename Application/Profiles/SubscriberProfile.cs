using Application.Models;
using AutoMapper;
using Domain.Entities;


namespace Application.Profiles
{
    internal class SubscriberProfile : Profile
    {
        public SubscriberProfile()
        {
            CreateMap<SubscriberDto, Subscriber>();
            CreateMap<Subscriber, SubscriberDto>();
        }
    }
}
