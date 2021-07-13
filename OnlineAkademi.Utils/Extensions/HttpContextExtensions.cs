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

        public static void SetCookie(this HttpContext context, string key, string value, TimeSpan expires)
        {
            CookieOptions opt = new CookieOptions
            {
                Expires = DateTime.Now.Add(expires)
            };
            context.Response.Cookies.Append(key, value, opt);
        }

        public static string GetCookie(this HttpContext context, string key)
        {
            if (context.HasCookie(key))
                return context.Request.Cookies[key];

            return null;
        }

        public static bool HasCookie(this HttpContext context, string key)
        {
            return context.Request.Cookies.ContainsKey(key);
        }

        public static void DeleteCookie(this HttpContext context, string key)
        {
            if (context.HasCookie(key))
                context.Response.Cookies.Delete(key);
        }

    }
}
