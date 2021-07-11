using AutoMapper;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Mappers
{
    public class ErrorMapper:Profile
    {
        public ErrorMapper()
        {
            CreateMap<Error, ErrorDto>();
            CreateMap<ErrorDto, Error>();
        }
    }
}
