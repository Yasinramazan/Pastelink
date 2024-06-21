using Application.Services.ApplicationExceptions;
using Domain.Entities.Identity;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Persistance.Abstractions.Pastes;
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
        private UserManager<AppUser> _userManager;
        private IHttpContextAccessor _httpContextAccessor;

        public ChangeAppUserPasswordHandler(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ChangeAppUserPasswordResponse> Handle(ChangeAppUserPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (user == null)
            {
                throw new UserException(UserExceptions.UserNotFound);
            }
            var result = await _userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);

            if(result.Succeeded)
            {
                return new();
            }
            throw new UserException(UserExceptions.ChangePasswordFailed);
            

        }
    }
}
