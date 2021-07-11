using OnlineAkademi.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Loggers
{
    public interface IExceptionLogger
    {
        void LogException(ErrorDto error);
    }
}
