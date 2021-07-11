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
    public class ErrorService : IErrorService
    {
        private readonly IMapper Mapper;
        private readonly IUnitWork Database;

        public ErrorService(IMapper mapper,IUnitWork uWork)
        {
            Mapper = mapper;
            Database = uWork;
        }

        public void AddError(ErrorDto errorDto)
        {
            var error = Mapper.Map<ErrorDto, Error>(errorDto);
            Database.ErrorRepo.Insert(error);
            Database.Commit();
        }
    }
}
