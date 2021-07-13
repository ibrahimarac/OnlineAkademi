using AutoMapper;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using OnlineAkademi.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Mappings
{
    public class MaterialMappings:Profile
    {
        public MaterialMappings()
        {
            CreateMap<MaterialDto, MaterialVM>();

            CreateMap<MaterialVM, MaterialDto>();
        }
    }
}
