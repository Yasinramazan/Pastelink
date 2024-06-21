using Application.Features.Command.AppUserCommand.LogOutUser;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.AppUserCommand.LogoutUser
{
    public class LogoutUserHandler : IRequestHandler<LogoutUserRequest, LogoutUserResponse>
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public LogoutUserHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LogoutUserResponse> Handle(LogoutUserRequest request, CancellationToken cancellationToken)
        {
            LogoutUserResponse response = new();
            try
            {
                await _signInManager.SignOutAsync();
                response.Message = "Başarılı";
            }
            catch (Exception)
            {

                throw;
            }
           return response;
        }
    }
}
