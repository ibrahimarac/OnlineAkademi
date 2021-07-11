using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Utils.Extensions
{
    public static class PathExtensions
    {
        public static string QueryStringFromUrl(this string url)
        {
            if (url.IndexOf('?') >= 0)
                return url.Substring(url.IndexOf('?') + 1);
            return "";
        }
    }
}
