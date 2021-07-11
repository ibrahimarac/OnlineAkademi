using OnlineAkademi.Core.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Services
{
    public interface IErrorService
    {
        void AddError(ErrorDto errorDto);
    }
}
