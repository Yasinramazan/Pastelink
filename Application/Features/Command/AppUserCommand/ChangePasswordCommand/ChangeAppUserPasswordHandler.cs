
using Application.Services.ApplicationExceptions;
using Domain.Entities.Identity;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Persistance.Abstractions.Pastes;
using Persistance.Abstractions.UserAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Command.AppUserCommand.ChangePasswordCommand
{
    public class ChangeAppUserPasswordHandler : IRequestHandler<ChangeAppUserPasswordRequest, ChangeAppUserPasswordResponse>
    {
        private readonly IUserService<AppUser> _userService;
        private readonly IHttpContextAccessor _contextAccessor;

        public ChangeAppUserPasswordHandler(IHttpContextAccessor contextAccessor, IUserService<AppUser> userService)
        {
            _contextAccessor = contextAccessor;
            _userService = userService;
        }

        public async Task<ChangeAppUserPasswordResponse> Handle(ChangeAppUserPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.FindByIdAsync(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                throw new UserException(UserExceptions.UserNotFound);
            }
            var result = await _userService.ChangePasswordAsync(user, request.Password, request.NewPassword);

            if(result.Succeeded)
            {
                return new();
            }
            throw new UserException(UserExceptions.ChangePasswordFailed);
            

        }
    }
}
