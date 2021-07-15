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

        public static string ParseStringToFormalUrl(this string url,char seperator)
        {
            return url.ToLower()
                .Replace(' ', seperator)
                .Replace('ç', 'c')
                .Replace('ş', 's')
                .Replace('ö', 'o')
                .Replace('ğ', 'g')
                .Replace('ü', 'u')
                .Replace('ı', 'i');
        }

    }
}
