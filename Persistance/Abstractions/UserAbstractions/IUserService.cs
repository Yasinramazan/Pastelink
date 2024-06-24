using Azure.Core;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Abstractions.UserAbstractions
{
    public interface IUserService<T> where T : AppUser
    {
        Task<AppUser> FindByIdAsync(string Id);
        Task<IdentityResult> SetLockoutEnabledAsync(T user, bool banLock);
        Task<IdentityResult> ChangePasswordAsync(T user, string password, string newPassword);
        Task<IdentityResult> CreateAsync(T user, string password);
        Task<AppUser> FindByEmailAsync(string email);
        Task<SignInResult> PasswordSignInAsync(T user,string password, bool persistance,bool lockout);
        void SignOut();
    }
}
