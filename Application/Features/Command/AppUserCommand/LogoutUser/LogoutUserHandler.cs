
using Application.Features.Command.AppUserCommand.LogOutUser;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistance.Abstractions.UserAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.AppUserCommand.LogoutUser
{
    public class LogoutUserHandler : IRequestHandler<LogoutUserRequest, LogoutUserResponse>
    {
        private readonly IUserService<AppUser> _userService;

        public LogoutUserHandler(IUserService<AppUser> userService)
        {
            _userService = userService;
        }

        public async Task<LogoutUserResponse> Handle(LogoutUserRequest request, CancellationToken cancellationToken)
        {
            LogoutUserResponse response = new();
            try
            {
                _userService.SignOut();
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
