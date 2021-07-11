using AutoMapper;
using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Domain.Entities;
using OnlineAkademi.Core.Loggers;
using OnlineAkademi.Core.Repositories;
using OnlineAkademi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Utils.Loggers
{
    public class DbCrudOperationLogger : ICrudOperationLogger
    {
        private readonly ICrudLoggerRepository _logCrudRepo;
        private readonly IMapper _mapper;

        public DbCrudOperationLogger(ICrudLoggerRepository logCrudRepo,IMapper mapper)
        {
            _logCrudRepo = logCrudRepo;
            _mapper = mapper;
        }

        public void LogCrudOperation(IEnumerable<LogDto> logs)
        {
            var logEntities = _mapper.Map<IEnumerable<LogDto>, IEnumerable<Log>>(logs);
            _logCrudRepo.Insert(logEntities);
        }
    }
}
