using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Dtos;
using Data.Entities;
using AutoMapper;

namespace Core.MapperProfile
{
    public class AppProfile:Profile
    {
        public AppProfile()
        {
            CreateMap<SparePartDto,SparePart>().ReverseMap();
            CreateMap<CreateSparePartDto,SparePart>();
            CreateMap<EditSparePartDto,SparePart>();
        }
    }
}
