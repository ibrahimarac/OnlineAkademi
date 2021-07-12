using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Core.Domain.Dto.Identity
{
    public class RegisterDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}
