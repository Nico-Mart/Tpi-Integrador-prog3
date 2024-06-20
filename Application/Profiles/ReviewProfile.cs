using Application.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
        CreateMap<ReviewDto, Review>();
        }
        
    }
}
