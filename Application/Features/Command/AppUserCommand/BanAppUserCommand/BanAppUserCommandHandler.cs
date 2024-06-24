
using Application.Services.ApplicationExceptions;
using Domain.Entities.Identity;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistance.Abstractions.UserAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.AppUserCommand.BanAppUserCommand
{
    public class BanAppUserCommandHandler : IRequestHandler<BanAppUserCommandRequest, BanAppUserCommandResponse>
    {
        private readonly IUserService<AppUser> _userService;

        public BanAppUserCommandHandler(IUserService<AppUser> userService)
        {
            _userService = userService;
        }

        public async Task<BanAppUserCommandResponse> Handle(BanAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userService.FindByIdAsync(request.Id);

            if (user == null)
            {
                throw new UserException(UserExceptions.UserNotFound);
            }

            var result = await _userService.SetLockoutEnabledAsync(user, true);

            if(result.Succeeded)
            {
                return new();
            }

            throw new NotImplementedException();
        }
    }
}
