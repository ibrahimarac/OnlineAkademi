using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace OnlineAkademi.Utils.Extensions
{
    public static class IdentityExtension
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

    }
}
