using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Abstractions
{
    public interface IPermanent
    {
        bool? IsActive { get; set; }
    }
}
