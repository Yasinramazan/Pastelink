using Application.Services.ApplicationExceptions;
using Domain.Entities.Identity;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.AppUserCommand.BanAppUserCommand
{
    public class BanAppUserCommandHandler : IRequestHandler<BanAppUserCommandRequest, BanAppUserCommandResponse>
    {
        private UserManager<AppUser> _userManager;

        public BanAppUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<BanAppUserCommandResponse> Handle(BanAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByIdAsync(request.Id);

            if (user == null)
            {
                throw new UserException(UserExceptions.UserNotFound);
            }

            var result = await _userManager.SetLockoutEnabledAsync(user, true);

            if(result.Succeeded)
            {
                return new();
            }

            throw new NotImplementedException();
        }
    }
}
