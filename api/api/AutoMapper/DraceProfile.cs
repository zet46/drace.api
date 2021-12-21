using api.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.AutoMapper
{
    public class DraceProfile : Profile
    {
        public DraceProfile()
        {
            CreateMap<Item, RacingItemDto>();
        }
    }
}
