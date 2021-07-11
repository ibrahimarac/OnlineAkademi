using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Utils.Extensions
{
    public static class HttpContextExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Headers != null&&request.Headers.ContainsKey("X-Requested-With"))
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }
    }
}
