
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Persistance.Abstractions.UserAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Concrete.Repositories.UserService
{
    public class UserManagerService<T> : IUserService<T> where T : AppUser
    {
        private UserManager<T> _userManager;
        private SignInManager<T> _signInManager;

        public UserManagerService(UserManager<T> userManager, SignInManager<T> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> ChangePasswordAsync(T user, string password, string newPassword)
        {
            IdentityResult result = await _userManager.ChangePasswordAsync(user, password, newPassword);
            return result;
        }

        public async Task<IdentityResult> CreateAsync(T user, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public async Task<AppUser> FindByEmailAsync(string email)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<AppUser> FindByIdAsync(string Id)
        {
            AppUser user = await _userManager.FindByIdAsync(Id);
            return user;
        }

        public async Task<IdentityResult> SetLockoutEnabledAsync(T user, bool banLock)
        {
            IdentityResult result = await _userManager.SetLockoutEnabledAsync(user, banLock);
            return result;

        }

        public async Task<SignInResult> PasswordSignInAsync(T user, string password, bool persistance, bool lockout)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(user,password,persistance,lockout);
            return result;
        }

        public async void SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
