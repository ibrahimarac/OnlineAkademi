using OnlineAkademi.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAkademi.Web.Models.VM
{
    public class ErrorVM
    {
        public string Url { get; set; }
        public string Message { get; set; }
        public RequestType  RequestType { get; set; }
        public int StatusCode { get; set; }

    }
}
