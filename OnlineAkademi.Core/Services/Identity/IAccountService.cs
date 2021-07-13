using OnlineAkademi.Core.Domain.Dto.Identity;
using OnlineAkademi.Core.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAkademi.Core.Services
{
    public interface IAccountService
    {
        Task<bool> Register(RegisterDto register);

        Task<bool> Login(LoginDto login);

        Task<bool> UserExists(string userName);

        Task<bool> DeleteUser(string userName);

        Task<bool> UpdateUser(RegisterDto register);

        Task<AppUser> GetUserAsync(string userName);

        Task<IList<string>> GetRolesForUser(AppUser user);

        Task<bool> AddUserToRole(string userName,string roleName);

        Task Logout();
    }
}
