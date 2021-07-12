using AutoMapper;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Dto.Identity;
using OnlineAkademi.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Mappings
{
    public class LoginMappings:Profile
    {
        public LoginMappings()
        {
            CreateMap<LoginDto, LoginVM>();
            CreateMap<LoginVM, LoginDto>();
        }
    }
}
