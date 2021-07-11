using OnlineAkademi.Core.Domain.Dto;
using OnlineAkademi.Core.Loggers;
using OnlineAkademi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Utils.Loggers
{
    public class DbExceptionLogger:IExceptionLogger
    {
        private readonly IErrorService _errorService;

        public DbExceptionLogger(IErrorService errorService)
        {
            _errorService = errorService;
        }

        public void LogException(ErrorDto error)
        {
            _errorService.AddError(error);
        }

        
    }
}
