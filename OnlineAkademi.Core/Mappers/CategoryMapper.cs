using AutoMapper;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Mappers
{
    public class CategoryMapper:Profile
    {
        public CategoryMapper()
        {
            //Entity To Dto
            CreateMap<Category, CategoryDto>();

            //Dto to Entity
            CreateMap<CategoryDto, Category>();
        }
    }
}
