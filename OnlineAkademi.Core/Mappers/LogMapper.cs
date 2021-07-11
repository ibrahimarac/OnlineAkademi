using AutoMapper;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Mappers
{
    public class LogMapper:Profile
    {
        public LogMapper()
        {
            //Entity To Dto
            CreateMap<Log, LogDto>();

            //Dto To Entity
            CreateMap<LogDto, Log>();
        }
    }
}
