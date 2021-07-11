using OnlineAkademi.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Loggers
{
    public interface ICrudOperationLogger
    {
        void LogCrudOperation(IEnumerable<LogDto> logs);
    }
}
