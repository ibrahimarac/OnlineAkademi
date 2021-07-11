using AutoMapper;
using OnlineAkademi.Core;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using OnlineAkademi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Services.Services
{
    public class LogCrudService : ILogCrudService
    {
        private readonly IMapper Mapper;
        private readonly IUnitWork Database;

        public LogCrudService(IMapper mapper, IUnitWork uWork)
        {
            Mapper = mapper;
            Database = uWork;
        }

    }
}
